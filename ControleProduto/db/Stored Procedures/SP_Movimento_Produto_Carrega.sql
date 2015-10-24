use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_Movimento_Produto_Carrega;    //
	CREATE PROCEDURE SP_Movimento_Produto_Carrega(IN _NCDPRODUTOMOVIMENTO INT, IN _DTMOVIMENTODE DATETIME, IN _DTMOVIMENTOATE DATETIME, IN _NCDPRODUTO INT, IN _CDSTIPOMOVIMENTO CHAR(1))
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			31/08/2015
			Banco de Dados:	Produto
            Procedure:		SP_Movimento_Produto_Carrega
            Versão:			1.0            
			Descrição:		Procedure que Carrega Movimento de Produto filtrado por:            
							-Código do Movimento	,
                            -Data Movimento De		,
                            -Data Movimento Ate		,
                            -Código do Produto		,
                            -Tipo do Movimento                            
		-- =======================================================================================                  
		*/

		-- =======================================================================================	
		-- DEFINE VALOR PARA VARIÁVEIS
		-- =======================================================================================	        
		IF NOT _DTMOVIMENTODE IS NULL  THEN
			SET _DTMOVIMENTODE = (SELECT DATE_FORMAT(_DTMOVIMENTODE, '%Y-%m-%d 00:00') DATEONLY);            
        END IF;
        
		IF NOT _DTMOVIMENTOATE IS NULL  THEN
			SET _DTMOVIMENTOATE = (SELECT DATE_FORMAT(_DTMOVIMENTOATE, '%Y-%m-%d 23:59') DATEONLY);
        END IF;        
        
		-- =======================================================================================	
		-- RETORNO DE DADOS
		-- =======================================================================================	
        SET @query = '	SELECT 
									A.NCDPRODUTOMOVIMENTO			,
									A.NCDPRODUTO					,
									B.CDSPRODUTO					,
									A.NQTPRODUTOMOVIMENTO			,
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
        
        IF _DTMOVIMENTODE IS NOT NULL OR _DTMOVIMENTOATE IS NOT NULL THEN 		
			IF _DTMOVIMENTODE IS NOT NULL AND _DTMOVIMENTOATE IS NULL THEN
				SET @query = CONCAT(@query, ' AND A.DTMOVIMENTO >=', (''+ _DTMOVIMENTODE +''));
			ELSEIF _DTMOVIMENTODE IS NULL AND _DTMOVIMENTOATE IS NOT NULL THEN				
                SET @query = CONCAT(@query, ' AND A.DTMOVIMENTO <=', (''+ _DTMOVIMENTOATE +''));
			ELSE 
				SET @query = CONCAT(@query, ' AND A.DTMOVIMENTO BETWEEN ', (''+ _DTMOVIMENTODE +''), ' AND ', (''+ _DTMOVIMENTOATE +''));
			END IF;
        END IF;
        
		IF _NCDPRODUTO > 0 THEN 
			SET @query = CONCAT(@query, ' AND A.NCDPRODUTO=', _NCDPRODUTO);
        END IF;        

		IF LENGTH(LTRIM(RTRIM(_CDSTIPOMOVIMENTO))) > 0 THEN			            
            SET @query = CONCAT(@query, ' AND A.CDSTIPOMOVIMENTO LIKE ''%', _CDSTIPOMOVIMENTO,'%''');
        END IF;
        
        SET @query = CONCAT(@query, ' ORDER BY DTMOVIMENTO');
        
        PREPARE stmt1 FROM @query;
		EXECUTE stmt1;
    END //
DELIMITER ;