 CREATE TABLE livro (
    id int NOT NULL UNIQUE,
    isbn varchar(255) NOT NULL UNIQUE,
    autor varchar(255),
    nome varchar(255),
    preco varchar(255),
	dt_publicacao varchar(255),
    img_capa varchar(255),
	CONSTRAINT pk_id PRIMARY KEY (id)
);