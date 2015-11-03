use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_SG_UsuarioAcessoPagina_Carrega;    //
	CREATE PROCEDURE SP_SG_UsuarioAcessoPagina_Carrega(IN _CNMUSUARIO VARCHAR(200), IN _NCDFUNCIONALIDADE INT, IN _NCDSUBFUNCIONALIDADE INT)
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			03/11/2015
			Banco de Dados:	Produto
            Versão:			1.0
            Procedure:		SP_SG_UsuarioAcessoPagina_Carrega
			Descrição:		Procedure que Retorna permissão de Login de Usuário para acesso a uma  Funcionalidade ou SubFuncionalidade
		-- =======================================================================================                  
		*/
		-- =======================================================================================	
		-- DECLARAÇÃO DE VARIÁVEIS
		-- =======================================================================================	
        DECLARE _NCDUSUARIO  INT DEFAULT 0;        
        DECLARE _MENSAGEM VARCHAR(100);        
        
		-- =======================================================================================	
		-- DEFINE VALOR PARA VARIÁVEIS
		-- =======================================================================================	        
        SET _NCDUSUARIO = (SELECT NCDUSUARIO FROM TBUSUARIO WHERE CNMUSUARIO = _CNMUSUARIO);
        
		IF _NCDFUNCIONALIDADE IS NOT NULL AND _NCDSUBFUNCIONALIDADE IS NULL THEN
			-- ===================================================================================
			-- RETORNO DE DADOS (PERMISSÃO DE FUNCIONALIDADE)
			-- ===================================================================================        
			IF EXISTS(	SELECT 	* 
						FROM 	TBPERMISSAOACESSO 
						WHERE 	NCDFUNCIONALIDADE 		= _NCDFUNCIONALIDADE 						
						AND		NCDUSUARIO				= _NCDUSUARIO) THEN
				SET		_MENSAGEM = 'Acesso Permitido!';            
				SELECT 
						1 			AS RETORNO	,
						_MENSAGEM 	AS MENSAGEM	;
			ELSE
				SET		_MENSAGEM = 'Acesso Negado!';            
				SELECT 
						0			AS RETORNO	,
						_MENSAGEM 	AS MENSAGEM	;
			END IF;     
        END IF;
        
		IF _NCDFUNCIONALIDADE IS NOT NULL AND _NCDSUBFUNCIONALIDADE IS NOT NULL THEN
			-- ===================================================================================
			-- RETORNO DE DADOS (PERMISSÃO DE SUBFUNCIONALIDADE)
			-- ===================================================================================        
			IF EXISTS(	SELECT 	* 
						FROM 	TBPERMISSAOACESSO 
						WHERE 	NCDFUNCIONALIDADE 		= _NCDFUNCIONALIDADE 
						AND 	NCDSUBFUNCIONALIDADE	= _NCDSUBFUNCIONALIDADE
						AND		NCDUSUARIO				= _NCDUSUARIO) THEN
				SET		_MENSAGEM = 'Acesso Permitido!';            
				SELECT 
						1 			AS RETORNO	,
						_MENSAGEM 	AS MENSAGEM	;
			ELSE
				SET		_MENSAGEM = 'Acesso Negado!';            
				SELECT 
						0 			AS RETORNO	,
						_MENSAGEM 	AS MENSAGEM	;
			END IF; 
        END IF;        

    END //
DELIMITER ;