	use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_SG_Usuario_IncluiAtualiza;    //
	CREATE PROCEDURE SP_SG_Usuario_IncluiAtualiza(IN _NCDUSUARIO INT, IN _CDSUSUARIO VARCHAR(100), IN _CNMUSUARIO VARCHAR(100), IN _BIDATIVO BOOLEAN, IN _ACAO INT)
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			03/11/2015
			Banco de Dados:	Produto
            Procedure:		SP_SG_Usuario_IncluiAtualiza
            Versão:			1.0            
			Descrição:		Procedure que realiza inclusão, alteração de Usuário.
							Ação >>	1: Inclusão
									2: Alteração									         
		-- =======================================================================================                  
		*/
        
		-- =======================================================================================	
		-- DECLARAÇÃO DE VARIÁVEIS
		-- =======================================================================================	
        DECLARE _MENSAGEM VARCHAR(100);       
        
        IF _ACAO = 1 THEN
        
			IF EXISTS(SELECT * FROM TBUSUARIO WHERE CNMUSUARIO = _CNMUSUARIO) THEN
				-- ===============================================================================
				-- RETORNO DE DADOS
				-- ===============================================================================            
				SET _MENSAGEM = 'Usuário já existe no sistema!';
                SELECT _MENSAGEM AS MENSAGEM, 0 AS RETORNO;
			ELSE 
				-- ===============================================================================
				-- INSERT
				-- ===============================================================================
				INSERT 
				INTO 	TBUSUARIO 
				(
						CDSUSUARIO,
						CNMUSUARIO,                                      
						BIDATIVO
				)
				VALUES
				(
						_CDSUSUARIO,
						_CNMUSUARIO,                                       
						_BIDATIVO
				);				
				-- ===============================================================================
				-- RETORNO DE DADOS
				-- ===============================================================================
				SET _MENSAGEM = 'Usuário inserido com sucesso!';
				SELECT LAST_INSERT_ID() AS NCDUSUARIO, _MENSAGEM AS MENSAGEM, 1 AS RETORNO;               
            END IF;
     
        END IF;
        
        IF _ACAO = 2 THEN			
			-- ===================================================================================
			-- UPDATE
			-- ===================================================================================	                        
			UPDATE	
					TBUSUARIO
            SET		CDSUSUARIO 	= 	_CDSUSUARIO,
					CNMUSUARIO	= 	_CNMUSUARIO,                    
            		BIDATIVO 	= 	_BIDATIVO
            WHERE	NCDUSUARIO	= 	_NCDUSUARIO;
            
			-- ===================================================================================
			-- RETORNO DE DADOS
			-- ===================================================================================
			SET _MENSAGEM = 'Usuário atualizado com sucesso!';            
            SELECT _MENSAGEM AS MENSAGEM;        
        END IF; 
    END //
DELIMITER ;
