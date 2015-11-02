use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_SG_UsuarioLoginPermissaoAcesso_Inclui;    //
	CREATE PROCEDURE SP_SG_UsuarioLoginPermissaoAcesso_Inclui(IN _CNMUSUARIO VARCHAR(100), IN _NCDFUNCIONALIDADE INT, IN _NCDSUBFUNCIONALIDADE INT)
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			30/08/2015
			Banco de Dados:	Produto
            Procedure:		SP_SG_UsuarioLoginPermissaoAcesso_Inclui
            Versão:			1.0            
			Descrição:		Procedure que realiza inclusão de permissão de acesso.
							Ação >>	1: Inclusão
									2: Alteração									         
		-- =======================================================================================                  
		*/
        
		-- =======================================================================================	        
		-- DECLARAÇÃO DE VARIÁVEIS
		-- =======================================================================================	        
		DECLARE _NCDUSUARIO  INT DEFAULT 0;        
        DECLARE _MENSAGEM 	 VARCHAR(100);
        
		SET 	_NCDUSUARIO = (SELECT NCDUSUARIO FROM TBUSUARIO WHERE CNMUSUARIO = _CNMUSUARIO);

		-- ===================================================================================
		-- INSERSÃO DE DADOS
		-- ===================================================================================	                
		INSERT 
		INTO 	TBPERMISSAOACESSO 
		(
				NCDFUNCIONALIDADE,
				NCDSUBFUNCIONALIDADE,
                NCDUSUARIO,
                DDTINCLUSAO
		)
		VALUES
		(
				_NCDFUNCIONALIDADE,					
                _NCDSUBFUNCIONALIDADE,					
                _NCDUSUARIO,
                NOW()
		);               
		
		-- ===================================================================================
		-- RETORNO DE DADOS
		-- ===================================================================================
		SET _MENSAGEM = 'Permissão inserida com sucesso!';
		SELECT LAST_INSERT_ID() AS NCDPERMISSAOACESSO, _MENSAGEM AS MENSAGEM;        
 
    END //
DELIMITER ;
