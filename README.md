# Primeira API C#

Api feita com .net core 7.0 para aprender.

Minha primeira api em C# com consulta de dados em um banco de dados.

## Objetivo

Fiz essa api para entender como o C# funciona e se comporta, também para treinar e melhorar as minhas habilidades. Resolvi praticar fazendo tudo na mão, a conexão de banco, os sql sem ajuda de algum framework ou algo do tipo.
É algo bem básico, como dito apenas para aprender e entender. Vai me servir de base para projetos futuros.


## Banco de dados

O banco que usei foi um mysql, algo simples feito apenas para consultar as informações.

Para você poder utilizar um banco, basta você copiar a url de conexão com o seu banco de dados, e adicionar o trecho abaixo no appsettings.json, apenas colocando a url como valor do parâmetro "DefaultConnection".

```css
{
  "ConnectionStrings": {
    "DefaultConnection": "URL DE CONEXÃO COM O BANCO AQUI"
  }
}

```

E para criar a sua tabela de usuários. Você pode estar utilizando esse código abaixo.
```sql
CREATE TABLE `usuarios` (
	`idUsuario` int NOT NULL AUTO_INCREMENT,
	`nome` varchar(50) NOT NULL,
	`sobrenome` varchar(50) NOT NULL,
	`username` varchar(20) NOT NULL,
	`email` varchar(100) NOT NULL,
	`password` varchar(100) NOT NULL,
	`data_criacao` timestamp NOT NULL DEFAULT current_timestamp(),
	`ativo` tinyint(1) DEFAULT '0',
	`isAdmin` tinyint(1) DEFAULT '0',
	`podeEditar` tinyint(1) DEFAULT '0',
	PRIMARY KEY (`idUsuario`)
)
```

## Redes

Para me conhecer mais vou listar abaixo as minhas redes sociais para me encontrar.

- [💻 PORFOLIO](https://panegallito.vercel.app)

- [<img src="https://img.shields.io/badge/Instagram-E4405F?style=for-the-badge&logo=instagram&logoColor=white">](https://www.instagram.com/andrey_panegalli/)

- [<img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white">](https://www.linkedin.com/in/andrey-panegalli-2699811b0/)
