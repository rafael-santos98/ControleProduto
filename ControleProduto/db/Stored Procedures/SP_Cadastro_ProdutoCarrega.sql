use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_Cadastro_ProdutoCarrega;    //
	CREATE PROCEDURE SP_Cadastro_ProdutoCarrega(IN _NCDPRODUTO INT, IN _CDSPRODUTO VARCHAR(100), IN _BIDATIVO INT)
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			30/08/2015
			Banco de Dados:	Produto
            Versão:			1.0
            Procedure:		SP_Cadastro_ProdutoCarrega
			Descrição:		Procedure que Carrega Produto filtrado por:
								-Código		, 
								-Descrição	,
								-BidAtivo.							          
		-- =======================================================================================                  
		*/
        
		-- =======================================================================================	
		-- RETORNO DE DADOS
		-- =======================================================================================	
        SET @query = '	SELECT
								NCDPRODUTO	,
								CDSPRODUTO	,
								NVLSALDO	,
								BIDATIVO	,
								CASE BIDATIVO 
									WHEN ''1'' THEN ''Sim'' 
									WHEN ''0'' THEN ''Não''									
								END AS BIDATIVO_TEXTO                                
						FROM 	TBPRODUTO
						WHERE 	0=0
					 ';
                     
		IF _NCDPRODUTO > 0 THEN 
			SET @query = CONCAT(@query, ' AND NCDPRODUTO=', _NCDPRODUTO);
        END IF;
        
        IF LENGTH(LTRIM(RTRIM(_CDSPRODUTO))) > 0 THEN
			SET @query = CONCAT(@query, ' AND CDSPRODUTO LIKE ''%', _CDSPRODUTO,'%''');
        END IF;
        
        IF _BIDATIVO > 0 THEN 
			IF _BIDATIVO = 1 THEN
				SET @query = CONCAT(@query, ' AND BIDATIVO=', 1);
			END IF;
                
            IF _BIDATIVO = 2 THEN
				SET @query = CONCAT(@query, ' AND BIDATIVO=', 0);
            END IF;
        END IF;
        
        SET @query = CONCAT(@query, ' ORDER BY CDSPRODUTO');
        
        PREPARE stmt1 FROM @query;
		EXECUTE stmt1;
    END //
DELIMITER ;