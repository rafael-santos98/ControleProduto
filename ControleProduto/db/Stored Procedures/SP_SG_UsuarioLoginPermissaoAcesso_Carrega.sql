use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_SG_UsuarioLoginPermissaoAcesso_Carrega;    //
	CREATE PROCEDURE SP_SG_UsuarioLoginPermissaoAcesso_Carrega(IN _CNMUSUARIO VARCHAR(100), IN ACAO INT)
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			02/11/2015
			Banco de Dados:	Produto
            Procedure:		SP_SG_UsuarioLoginPermissaoAcesso_Carrega
            Versão:			1.0            
			Descrição:		Procedure que Carrega Permissões de Acesso de Usuário                            
							Ação >>	1: Carrega Permissões Não Associadas
									2: Carrega Permissões Associadas
		-- =======================================================================================                  
		*/
		-- =======================================================================================	        
		-- DECLARAÇÃO DE VARIÁVEIS
		-- =======================================================================================	        
		DECLARE _NCDUSUARIO  INT DEFAULT 0;        
		SET 	_NCDUSUARIO = (SELECT NCDUSUARIO FROM TBUSUARIO WHERE CNMUSUARIO = _CNMUSUARIO);
        
        IF ACAO = 1 THEN			
			-- =======================================================================================	
			-- RETORNO DE DADOS
			-- =======================================================================================	
			SELECT 	A.NCDFUNCIONALIDADE,
					A.CDSFUNCIONALIDADE,
					A.NCDSUBFUNCIONALIDADE,
					A.CDSSUBFUNCIONALIDADE,
                    A.BIDATIVO,
					CONCAT(A.CDSFUNCIONALIDADE,  A.CDSSUBFUNCIONALIDADE)  AS CODDESC
			FROM 		(	SELECT 
										A.NCDFUNCIONALIDADE		,
										A.CDSFUNCIONALIDADE		,
										''						AS NCDSUBFUNCIONALIDADE,
										''						AS CDSSUBFUNCIONALIDADE,
										A.BIDATIVO				
							FROM 		TBFUNCIONALIDADE		A
							WHERE		A.NCDFUNCIONALIDADE		NOT IN	(	SELECT 
																					X.NCDFUNCIONALIDADE 
																			FROM 	TBPERMISSAOACESSO 		X
																			WHERE	X.NCDUSUARIO			=  _NCDUSUARIO)
							UNION
																		
							SELECT 		B.NCDFUNCIONALIDADE		,
										C.CDSFUNCIONALIDADE		,
										B.NCDSUBFUNCIONALIDADE	,
										B.CDSSUBFUNCIONALIDADE	,
										C.BIDATIVO
							FROM    	TBSUBFUNCIONALIDADE 	B
							LEFT JOIN	TBFUNCIONALIDADE		C
							ON			B.NCDFUNCIONALIDADE		=	C.NCDFUNCIONALIDADE
							WHERE		B.NCDSUBFUNCIONALIDADE	NOT IN	(	SELECT 
																					Y.NCDSUBFUNCIONALIDADE 
																			FROM 	TBPERMISSAOACESSO 		Y
																			WHERE	Y.NCDUSUARIO			= _NCDUSUARIO
																			AND		Y.NCDSUBFUNCIONALIDADE IS NOT NULL
																			AND		Y.NCDFUNCIONALIDADE	   IS NOT NULL	)) A ORDER BY A.CDSFUNCIONALIDADE, A.CDSSUBFUNCIONALIDADE;         
        
		END IF;
		IF ACAO = 2 THEN
			-- =======================================================================================	
			-- RETORNO DE DADOS
			-- =======================================================================================	
			SELECT 	A.NCDFUNCIONALIDADE,
					A.CDSFUNCIONALIDADE,
					A.NCDSUBFUNCIONALIDADE,
					A.CDSSUBFUNCIONALIDADE,
                    A.BIDATIVO,
					CONCAT(A.CDSFUNCIONALIDADE,  A.CDSSUBFUNCIONALIDADE)  AS CODDESC
			FROM 		(	SELECT 
										A.NCDFUNCIONALIDADE		,
										A.CDSFUNCIONALIDADE		,
										''						AS NCDSUBFUNCIONALIDADE,
										''						AS CDSSUBFUNCIONALIDADE,
										A.BIDATIVO				
							FROM 		TBFUNCIONALIDADE		A
							WHERE		A.NCDFUNCIONALIDADE			IN	(	SELECT 
																					X.NCDFUNCIONALIDADE 
																			FROM 	TBPERMISSAOACESSO 		X
																			WHERE	X.NCDUSUARIO			=  _NCDUSUARIO)
							UNION
																		
							SELECT 		B.NCDFUNCIONALIDADE		,
										C.CDSFUNCIONALIDADE		,
										B.NCDSUBFUNCIONALIDADE	,
										B.CDSSUBFUNCIONALIDADE	,
										C.BIDATIVO
							FROM    	TBSUBFUNCIONALIDADE 	B
							LEFT JOIN	TBFUNCIONALIDADE		C
							ON			B.NCDFUNCIONALIDADE		=	C.NCDFUNCIONALIDADE
							WHERE		B.NCDSUBFUNCIONALIDADE		IN	(	SELECT 
																					Y.NCDSUBFUNCIONALIDADE 
																			FROM 	TBPERMISSAOACESSO 		Y
																			WHERE	Y.NCDUSUARIO			= _NCDUSUARIO
																			AND		Y.NCDSUBFUNCIONALIDADE IS NOT NULL
																			AND		Y.NCDFUNCIONALIDADE	   IS NOT NULL	)) A ORDER BY A.CDSFUNCIONALIDADE, A.CDSSUBFUNCIONALIDADE;   
		END IF;
    END //
DELIMITER ;