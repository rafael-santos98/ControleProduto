use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_SG_UsuarioPermissaoAcesso_Carrega;    //
	CREATE PROCEDURE SP_SG_UsuarioPermissaoAcesso_Carrega(IN _CNMUSUARIO VARCHAR(100), IN _ACAO INT)
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			02/11/2015
			Banco de Dados:	Produto
            Procedure:		SP_SG_UsuarioPermissaoAcesso_Carrega
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
        
        IF _ACAO = 1 THEN			
			-- =======================================================================================	
			-- RETORNO DE DADOS
			-- =======================================================================================	
			SELECT 	A.NCDFUNCIONALIDADE,
					A.CDSFUNCIONALIDADE,
					A.NCDSUBFUNCIONALIDADE,
					A.CDSSUBFUNCIONALIDADE,
                    A.BIDATIVO,
                    CONCAT(A.NCDFUNCIONALIDADE, ' | ', IFNULL(A.NCDSUBFUNCIONALIDADE, '0')) AS NCDFUNSUB,
					CONCAT(A.CDSFUNCIONALIDADE,  IFNULL(A.CDSSUBFUNCIONALIDADE,''))  AS CDSCFUNSUB
			FROM 		(	SELECT 
										A.NCDFUNCIONALIDADE		,
										A.CDSFUNCIONALIDADE		,
										NULL						AS NCDSUBFUNCIONALIDADE,
										NULL						AS CDSSUBFUNCIONALIDADE,
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
		IF _ACAO = 2 THEN
			-- =======================================================================================	
			-- RETORNO DE DADOS
			-- =======================================================================================	
            SELECT 		A.NCDPERMISSAOACESSO,
						A.NCDFUNCIONALIDADE,
						B.CDSFUNCIONALIDADE,
						A.NCDSUBFUNCIONALIDADE,
						C.CDSSUBFUNCIONALIDADE,
                        B.BIDATIVO,
                        CONCAT(B.CDSFUNCIONALIDADE,IFNULL(C.CDSSUBFUNCIONALIDADE, '')) AS CDSCFUNSUB
			FROM 		TBPERMISSAOACESSO		A
			INNER JOIN	TBFUNCIONALIDADE		B
			ON			A.NCDFUNCIONALIDADE		=	B.NCDFUNCIONALIDADE
			LEFT JOIN	TBSUBFUNCIONALIDADE		C
			ON			A.NCDSUBFUNCIONALIDADE 	= C.NCDSUBFUNCIONALIDADE
			INNER JOIN	TBUSUARIO				D
			ON			A.NCDUSUARIO			=	D.NCDUSUARIO
            WHERE		D.NCDUSUARIO			=	_NCDUSUARIO
			ORDER BY 	B.CDSFUNCIONALIDADE, 
						C.CDSSUBFUNCIONALIDADE;     
		END IF;
    END //
DELIMITER ;