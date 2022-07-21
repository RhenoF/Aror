# Aror

### Sobre

Aror é uma ferramenta de pesquisa sobre o impacto de eventos *mundiais* e *nacionais* nas vendas de medicamentos no **Brasil**.
Adaptado para a formatação das tabelas da **Datavisa** e atualmente funcionando apenas para quantificar as vendas de *antidepressivos* e *ansiolíticos* no **Mariadb**.

### Como Usar

Primeiro, precisa-se coletar os *datasets* do período escolhido para a pesquisa no **[Portal de Dados Abertos do Governo Federal](https://dados.gov.br/)**.
Após a coleta, os arquivos precisam ser *mesclados* através da ferramenta de sua escolha ou pelo **[Prompt de Comando](https://thiagottss.wordpress.com/2018/12/12/como-juntar-merge-varios-arquivos-csv-em-um-unico-arquivo-csv/#:~:text=SOLU%C3%87%C3%83O%3A,em%20um%20%C3%BAnico%20arquivo%20novo.)**.
Para rodar Aror, precisa-se ter um *gerenciador de banco de dados* que funcione com o **[Mariadb](https://mariadb.com/kb/pt-br/sobre-o-mariadb/)** e substituir os dados necessários nessa parte do código:


            var builder = new MySqlConnectionStringBuilder
            {
                Server = "MariaDB",
                UserID = "root@localhost",
                Password = "1234",
                Database = "aror",
            };


O tempo para chegar ao resultado depende do tamanho do dataset utilizado.

### Futuro do Aror

1. Melhorar a interface
     1. Barra de carregamento
     2. Design
2. Incluir outros tipos de medicamentos
