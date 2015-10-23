use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_Cadastro_Produto_Carrega;    //
	CREATE PROCEDURE SP_Cadastro_Produto_Carrega(IN _NCDPRODUTO INT, IN _CDSPRODUTO VARCHAR(100), IN _BIDATIVO BOOLEAN)
    BEGIN 	
    
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			30/08/2015
			Banco de Dados:	Produto
            Versão:			1.0
            Procedure:		SP_Cadastro_Produto_Carrega
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
								NCDPRODUTO					,
								CDSPRODUTO					,
								NQTPRODUTOSALDO				,
								BIDATIVO					,
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
        
        IF  NOT _BIDATIVO  IS NULL THEN
			SET @query = CONCAT(@query, ' AND BIDATIVO=', _BIDATIVO);
		END IF;
        
        SET @query = CONCAT(@query, ' ORDER BY CDSPRODUTO');
        
        PREPARE stmt1 FROM @query;
		EXECUTE stmt1;
    END //
DELIMITER ;