use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_Cadastro_ProdutoIncluiAtualizaExclui;    //
	CREATE PROCEDURE SP_Cadastro_ProdutoIncluiAtualizaExclui(IN _NCDPRODUTO INT, IN _CDSPRODUTO VARCHAR(100), IN _BIDATIVO BIT, IN _ACAO INT)
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			30/08/2015
			Banco de Dados:	Produto
            Procedure:		SP_Cadastro_ProdutoIncluiAtualizaExclui
            Versão:			1.0            
			Descrição:		Procedure que realiza inclusão, alteração e deleção de Produto.
							Ação >>	1: Inclusão
									2: Alteração
									3: Deleção            
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
			INTO 	TBPRODUTO (
					CDSPRODUTO,                 
					NVLSALDO, 
					BIDATIVO
			)
			VALUES
			(
					_CDSPRODUTO,
					0,
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
        
        IF _ACAO = 3 THEN
			-- ===================================================================================
			-- DELEÇÃO DE DADOS
			-- ===================================================================================	                        
			DELETE      
            FROM	TBPRODUTO
            WHERE 	NCDPRODUTO = _NCDPRODUTO;
            
			-- ===================================================================================
			-- RETORNO DE DADOS
			-- ===================================================================================
			SET _MENSAGEM = 'Produto deletado com sucesso!';   
            SELECT _MENSAGEM AS MENSAGEM;
        END IF;
    END //
DELIMITER ;
