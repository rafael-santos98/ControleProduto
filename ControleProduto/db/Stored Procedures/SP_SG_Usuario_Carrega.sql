use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_SG_Usuario_Carrega;    //
	CREATE PROCEDURE SP_SG_Usuario_Carrega(IN _NCDUSUARIO INT, IN _CDSUSUARIO VARCHAR(100), IN _CNMUSUARIO VARCHAR(100), IN _BIDATIVO BOOLEAN)
    BEGIN 	
    
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			03/11/2015
			Banco de Dados:	Produto
            Versão:			1.0
            Procedure:		SP_SG_Usuario_Carrega
			Descrição:		Procedure que Carrega Usuário filtrado por:
								-Código		, 
                                -Login		,
								-Nome		,
								-BidAtivo.							          
		-- =======================================================================================                  
		*/
        
		-- =======================================================================================	
		-- RETORNO DE DADOS
		-- =======================================================================================	
        SET @query = '	SELECT
								NCDUSUARIO					,
								CDSUSUARIO					,
                                CNMUSUARIO					,
                                CDSSENHA					,								
								BIDATIVO					,
								CASE BIDATIVO 
									WHEN ''1'' THEN ''Sim'' 
									WHEN ''0'' THEN ''Não''									
								END AS BIDATIVO_TEXTO                                
						FROM 	TBPRODUTO
						WHERE 	0=0
					 ';
                     
		IF _NCDUSUARIO > 0 THEN 
			SET @query = CONCAT(@query, ' AND NCDUSUARIO=', _NCDUSUARIO);
        END IF;
        
        IF LENGTH(LTRIM(RTRIM(_CDSUSUARIO))) > 0 THEN
			SET @query = CONCAT(@query, ' AND CDSUSUARIO LIKE ''%', _CDSUSUARIO,'%''');
        END IF;
        
        IF LENGTH(LTRIM(RTRIM(_CNMUSUARIO))) > 0 THEN
			SET @query = CONCAT(@query, ' AND CNMUSUARIO LIKE ''%', _CNMUSUARIO,'%''');
        END IF;        
        
        IF  NOT _BIDATIVO  IS NULL THEN
			SET @query = CONCAT(@query, ' AND BIDATIVO=', _BIDATIVO);
		END IF;
        
        SET @query = CONCAT(@query, ' ORDER BY CDSUSUARIO');
        
        PREPARE stmt1 FROM @query;
		EXECUTE stmt1;
    END //
DELIMITER ;