use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_SG_UsuarioLogin_Carrega;    //
	CREATE PROCEDURE SP_SG_UsuarioLogin_Carrega(IN _CNMUSUARIO VARCHAR(200), IN _CDSSENHA VARCHAR(128))
    BEGIN 	
    
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			26/10/2015
			Banco de Dados:	Produto
            Versão:			1.0
            Procedure:		SP_SG_UsuarioLogin_Carrega
			Descrição:		Procedure que Retorna permissão de Login de Usuário
		-- =======================================================================================                  
		*/
		-- =======================================================================================	
		-- DECLARAÇÃO DE VARIÁVEIS
		-- =======================================================================================	
        DECLARE _MENSAGEM VARCHAR(100);        
        
		-- =======================================================================================	
		-- RETORNO DE DADOS
		-- =======================================================================================	        
        IF EXISTS(SELECT NCDUSUARIO FROM TBUSUARIO WHERE CNMUSUARIO = _CNMUSUARIO AND CDSSENHA = _CDSSENHA) THEN
			SET _MENSAGEM = 'Usuário autenticado com sucesso!';
            
            SELECT 
					_MENSAGEM 	AS MENSAGEM	,
					1 			AS RETORNO	,
                    NCDUSUARIO				,		 
                    CDSUSUARIO				, 
                    CNMUSUARIO				, 
                    CDSSENHA				, 
                    BIDATIVO                    
			FROM 	TBUSUARIO 
            WHERE 	CNMUSUARIO 	= _CNMUSUARIO 
            AND 	CDSSENHA 	= _CDSSENHA  ;          
		ELSE
			SET _MENSAGEM = 'Usuário e/ou Senha inválidos!';
			SELECT 0 AS RETORNO, _MENSAGEM;
        END IF;
    END //
DELIMITER ;