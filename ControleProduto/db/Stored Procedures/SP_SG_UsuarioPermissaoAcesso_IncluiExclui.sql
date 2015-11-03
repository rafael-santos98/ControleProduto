use produto;

DELIMITER 	//
	DROP PROCEDURE IF EXISTS SP_SG_UsuarioPermissaoAcesso_IncluiExclui;    //
	CREATE PROCEDURE SP_SG_UsuarioPermissaoAcesso_IncluiExclui(IN _NCDPERMISSAOACESSO INT, IN _CNMUSUARIO VARCHAR(100), IN _NCDFUNCIONALIDADE INT, IN _NCDSUBFUNCIONALIDADE INT, IN _ACAO INT)
    BEGIN 	
		/*
		-- =======================================================================================
			Sistema:  		Controle de Produto			
			Data:			30/08/2015
			Banco de Dados:	Produto
            Procedure:		SP_SG_UsuarioPermissaoAcesso_IncluiExclui
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
        
		IF _ACAO = 1 THEN
			-- ===================================================================================
			-- DEFINE VALOR PARA VARIÁVEL
			-- ===================================================================================	                        
			SET 	_NCDUSUARIO = (SELECT NCDUSUARIO FROM TBUSUARIO WHERE CNMUSUARIO = _CNMUSUARIO);        
        
			-- ===================================================================================
			-- INSERT
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
        END IF;
        
        IF _ACAO = 2 THEN
			-- ===================================================================================
			-- DELETE 
			-- ===================================================================================	  
            DELETE FROM TBPERMISSAOACESSO WHERE NCDPERMISSAOACESSO = _NCDPERMISSAOACESSO;
            SET _MENSAGEM = 'Permissão removida com sucesso!';

			-- ===================================================================================
			-- RETORNO DE DADOS
			-- ===================================================================================            
            SELECT _MENSAGEM AS MENSAGEM;
		END IF;
    END //
DELIMITER ;
