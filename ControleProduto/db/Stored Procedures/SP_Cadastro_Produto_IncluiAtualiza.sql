use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_Cadastro_Produto_IncluiAtualiza;    //
	CREATE PROCEDURE SP_Cadastro_Produto_IncluiAtualiza(IN _NCDPRODUTO INT, IN _CDSPRODUTO VARCHAR(100), IN _BIDATIVO BOOLEAN, IN _ACAO INT)
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			30/08/2015
			Banco de Dados:	Produto
            Procedure:		SP_Cadastro_Produto_IncluiAtualiza
            Versão:			1.0            
			Descrição:		Procedure que realiza inclusão, alteração de Produto.
							Ação >>	1: Inclusão
									2: Alteração									         
		-- =======================================================================================                  
		*/
        
		-- =======================================================================================	
		-- DECLARAÇÃO DE VARIÁVEIS
		-- =======================================================================================	
        DECLARE _MENSAGEM VARCHAR(100);
        
        IF _ACAO = 1 THEN
			-- ===================================================================================
			-- INSERSÃO DE DADOS
			-- ===================================================================================	                
			INSERT 
			INTO 	TBPRODUTO 
            (
					CDSPRODUTO,                 					
					BIDATIVO
			)
			VALUES
			(
					_CDSPRODUTO,					
					_BIDATIVO
			);               
			
			-- ===================================================================================
			-- RETORNO DE DADOS
			-- ===================================================================================
			SET _MENSAGEM = 'Produto inserido com sucesso!';
			SELECT LAST_INSERT_ID() AS NCDPRODUTO, _MENSAGEM AS MENSAGEM;        
        END IF;
        
        IF _ACAO = 2 THEN
			-- ===================================================================================
			-- ATUALIZAÇÃO DE DADOS
			-- ===================================================================================	                        
			UPDATE	
					TBPRODUTO
            SET		CDSPRODUTO 	= 	_CDSPRODUTO,
            		BIDATIVO 	= 	_BIDATIVO
            WHERE	NCDPRODUTO	= 	_NCDPRODUTO;
            
			-- ===================================================================================
			-- RETORNO DE DADOS
			-- ===================================================================================
			SET _MENSAGEM = 'Produto atualizado com sucesso!';            
            SELECT _MENSAGEM AS MENSAGEM;        
        END IF;
 
    END //
DELIMITER ;
