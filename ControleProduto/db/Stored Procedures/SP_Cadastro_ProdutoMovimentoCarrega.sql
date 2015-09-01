use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_Cadastro_ProdutoMovimentoCarrega;    //
	CREATE PROCEDURE SP_Cadastro_ProdutoMovimentoCarrega(IN _NCDPRODUTOMOVIMENTO INT, IN _DTENTRADA DATETIME, IN _DTSAIDA DATETIME, IN _NCDPRODUTO INT, IN _CDSTIPOMOVIMENTO CHAR(1))
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			31/08/2015
			Banco de Dados:	Produto
            Procedure:		SP_Cadastro_ProdutoMovimentoCarrega
            Versão:			1.0            
			Descrição:		Procedure que Carrega Movimento de Produto filtrado por:            
							-Código do Movimento	,
                            -Data de Entrada		,
                            -Data de Saída			,
                            -Código do Produto		,
                            -Tipo do Movimento                            
		-- =======================================================================================                  
		*/

		-- =======================================================================================	
		-- RETORNO DE DADOS
		-- =======================================================================================	
        SET @query = '	SELECT 
									A.NCDPRODUTOMOVIMENTO			,
									A.NCDPRODUTO					,
									B.CDSPRODUTO					,
									A.NVLQUANTIDADE					,
									A.CDSOBSERVACAO					,
									A.CDSTIPOMOVIMENTO				,
									CASE A.CDSTIPOMOVIMENTO 
										WHEN ''E'' THEN ''Entrada'' 
										WHEN ''S'' THEN ''Saída''
                                        WHEN ''C'' THEN ''Cancelar''
									END AS CDSTIPOMOVIMENTO_TEXTO	,				
									A.DTMOVIMENTO			
						FROM 		TBPRODUTOMOVIMENTO 				A
						INNER JOIN	TBPRODUTO						B
						ON 			A.NCDPRODUTO 					=	B.NCDPRODUTO
                        WHERE 		0=0
					 ';
        
		IF _NCDPRODUTOMOVIMENTO > 0 THEN 
			SET @query = CONCAT(@query, ' AND A.NCDPRODUTOMOVIMENTO=', _NCDPRODUTOMOVIMENTO);
        END IF;    
        /*
		IF _DTENTRADA IS NOT NULL OR _DTSAIDA IS NOT NULL THEN 		
            IF _DTENTRADA IS NOT NULL AND _DTSAIDA IS NULL THEN
				SET @query = CONCAT(@query, ' AND A.DTMOVIMENTO >=', _DTENTRADA);
			ELSEIF _DTENTRADA IS NULL AND _DTSAIDA IS NOT NULL THEN
				SET @query = CONCAT(@query, ' AND A.DTMOVIMENTO <=', _DTSAIDA);
			ELSE 
				SET @query = CONCAT(@query, ' AND A.DTMOVIMENTO BETWEEN ', _DTENTRADA, ' AND ', _DTSAIDA);
            END IF;			
        END IF;*/  
        
		IF _NCDPRODUTO > 0 THEN 
			SET @query = CONCAT(@query, ' AND A.NCDPRODUTO=', _NCDPRODUTO);
        END IF;        

		IF LENGTH(LTRIM(RTRIM(_CDSTIPOMOVIMENTO))) > 0 THEN			            
            SET @query = CONCAT(@query, ' AND A.CDSTIPOMOVIMENTO LIKE ''%', _CDSTIPOMOVIMENTO,'%''');
        END IF;
        
        PREPARE stmt1 FROM @query;
		EXECUTE stmt1;
    END //
DELIMITER ;