use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_SG_UsuarioSenha_Atualiza;    //
	CREATE PROCEDURE SP_SG_UsuarioSenha_Atualiza(IN _NCDUSUARIO INT, IN _CNMUSUARIO VARCHAR(100), IN _CDSSENHA VARCHAR(128))
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			07/11/2015
			Banco de Dados:	Produto
            Procedure:		SP_SG_UsuarioSenha_Atualiza
            Versão:			1.0            
			Descrição:		Procedure que realiza alteração de Senha do Usuário.								         
		-- =======================================================================================                  
		*/
        
		-- =======================================================================================	
		-- DECLARAÇÃO DE VARIÁVEIS
		-- =======================================================================================	
        DECLARE _MENSAGEM VARCHAR(100);               

		IF _NCDUSUARIO = 0 THEN		
			-- ===================================================================================
			-- DEFINE VALOR PARA VARIÁVEIS
			-- ===================================================================================
			SET _NCDUSUARIO = (SELECT NCDUSUARIO FROM TBUSUARIO WHERE CNMUSUARIO = _CNMUSUARIO);            
		END IF;
            
		-- =======================================================================================
		-- UPDATE
		-- =======================================================================================
		UPDATE	
				TBUSUARIO
		SET		CDSSENHA 	= UPPER(_CDSSENHA)
		WHERE	NCDUSUARIO	= _NCDUSUARIO;
		
		-- =======================================================================================
		-- RETORNO DE DADOS
		-- =======================================================================================
		SET _MENSAGEM = 'Senha de Usuário atualizada com sucesso!';            
		SELECT _MENSAGEM AS MENSAGEM;                
    END //
DELIMITER ;
