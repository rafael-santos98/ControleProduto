use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_Movimento_Produto_Inclui;    //
	CREATE PROCEDURE SP_Movimento_Produto_Inclui(IN _NCDPRODUTO INT, IN _NQTPRODUTOMOVIMENTO FLOAT, IN _CDSOBSERVACAO VARCHAR(300), IN _CDSTIPOMOVIMENTO CHAR(1))
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			31/08/2015
			Banco de Dados:	Produto
            Versão:			1.0
            Procedure:		SP_Movimento_Produto_Inclui
			Descrição:		Procedure que realiza inclusão Movimento de Produto.         
							-Entrada 	= 'E'	,
                            -Saída 	 	= 'S'	,
                            -Cancelado	= 'C'.
		-- =======================================================================================                  
		*/
        
		-- =======================================================================================	
		-- DECLARAÇÃO DE VARIÁVEIS
		-- =======================================================================================	
        DECLARE _MENSAGEM VARCHAR(100);

		-- =======================================================================================
		-- INSERSÃO DE DADOS
		-- =======================================================================================
        IF _CDSTIPOMOVIMENTO = 'E' THEN
			IF _NQTPRODUTOMOVIMENTO > 0 THEN
				BEGIN
					INSERT 
					INTO 	TBPRODUTOMOVIMENTO 
					(
							NCDPRODUTO				, 
							NQTPRODUTOMOVIMENTO		,	 
							CDSOBSERVACAO			, 
							CDSTIPOMOVIMENTO		, 
							DTMOVIMENTO	
					)
					VALUES
					(
							_NCDPRODUTO				, 
							_NQTPRODUTOMOVIMENTO	,	 
							_CDSOBSERVACAO			,	 
							_CDSTIPOMOVIMENTO		,	 
							NOW()
					);               
					
					-- ===================================================================================
					-- RETORNO DE DADOS
					-- ===================================================================================
					SET _MENSAGEM = 'Movimento de Produto inserido com sucesso!';
					SELECT LAST_INSERT_ID() AS NCDPRODUTOMOVIMENTO, _MENSAGEM AS MENSAGEM, '1' AS BIDAUTORIZACAO;                 
                END;
			ELSE 
				-- ===================================================================================
				-- RETORNO DE DADOS
				-- ===================================================================================
				SET _MENSAGEM = 'Quantidade de Movimento deve ser maior que zero!';
				SELECT LAST_INSERT_ID() AS NCDPRODUTOMOVIMENTO, _MENSAGEM AS MENSAGEM, '0' AS BIDAUTORIZACAO;  	
			END IF;                           
        END IF;        
        
        IF _CDSTIPOMOVIMENTO = 'S' OR _CDSTIPOMOVIMENTO = 'C' THEN
			IF _NQTPRODUTOMOVIMENTO <= (SELECT NQTPRODUTOSALDO FROM TBPRODUTO WHERE NCDPRODUTO = _NCDPRODUTO) THEN				
                IF _NQTPRODUTOMOVIMENTO > 0 THEN
					BEGIN
						INSERT 
						INTO 	TBPRODUTOMOVIMENTO 
						(
								NCDPRODUTO				, 
								NQTPRODUTOMOVIMENTO		,	 
								CDSOBSERVACAO			, 
								CDSTIPOMOVIMENTO		, 
								DTMOVIMENTO	
						)
						VALUES
						(
								_NCDPRODUTO				, 
								_NQTPRODUTOMOVIMENTO	,	 
								_CDSOBSERVACAO			,	 
								_CDSTIPOMOVIMENTO		,	 
								NOW()
						);               
						
						-- ===================================================================================
						-- RETORNO DE DADOS
						-- ===================================================================================
						SET _MENSAGEM = 'Movimento de Produto inserido com sucesso!';
						SELECT LAST_INSERT_ID() AS NCDPRODUTOMOVIMENTO, _MENSAGEM AS MENSAGEM, '1' AS BIDAUTORIZACAO;  				
					END;
				ELSE 
					-- ===================================================================================
					-- RETORNO DE DADOS
					-- ===================================================================================
					SET _MENSAGEM = 'Quantidade de Movimento deve ser maior que zero!';
					SELECT LAST_INSERT_ID() AS NCDPRODUTOMOVIMENTO, _MENSAGEM AS MENSAGEM, '0' AS BIDAUTORIZACAO;  	
				END IF;
 
			ELSE
				-- ===================================================================================
				-- RETORNO DE DADOS
				-- ===================================================================================
				SET _MENSAGEM = 'O Produto não possui Saldo em Estoque para fazer o Movimento!';
				SELECT _MENSAGEM AS MENSAGEM, '0' AS BIDAUTORIZACAO;    
			
			END IF;               
        END IF;
      
    END //
DELIMITER ;