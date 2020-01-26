create database statemovie;

use statemovie;

create table tbl_usuario(
usu_id int identity(1,1) not null,
cli_id int,
tus_id int,
usu_usu varchar(50) null,
usu_pass varchar(50) null,
primary key (usu_id)
);

create table tbl_tipo_usuario(
tus_id int identity(1,1) not null,
tus_desc varchar(50),
primary key (tus_id) 
);

create table tbl_cliente(
cli_id int identity(1,1) not null,
cli_ruc varchar(50) null,
cli_nom varchar(50) null,
cli_ape varchar(50) null,
cli_dire varchar(50) null,
cli_tel int null,
cli_corr varchar(100) null,
cli_fnaci varchar(50) null,
cli_est varchar(50),
primary key(cli_id)
);

create table tbl_tipo_pago(
tpag_id int identity(1,1) not null,
tpag_nom varchar(50),
primary key(tpag_id)
);

create table tbl_tarifa(
tar_id int identity(1,1) not null,
tar_val float null,
tar_det varchar(50) null,
tar_esta varchar(10) null,
primary key(tar_id)
);

create table tbl_tiket(
tik_id int identity(1,1) not null,
usu_id int null,
pel_id int null,
sal_id int null,
tpag_id int null,
tar_id int null,
tik_asien varchar(5) null,
tik_fec varchar(10) null,
tik_estd varchar(10) null,
primary key(tik_id)
);

create table tbl_pelicula(
pel_id int identity(1,1) not null,
pel_nom varchar(50) null,
pel_pro varchar(50) null,
pel_dire varchar(50) null,
pel_cla varchar(50) null,
pel_est varchar(10) null,
primary key(pel_id)
);

create table tbl_horario(
hor_id int identity(1,1) not null,
hor_hor varchar(50) null,
hor_det varchar(50) null,
hor_est varchar(10) null,
primary key(hor_id)
);

create table tbl_hor_pel(
pel_id int null,
hor_id int null
);

create table tbl_suc_tar(
suc_id int null,
tar_id int null
);

create table tbl_sala_suc(
sal_id int null,
suc_id int null
);

create table tbl_gene_peli(
gen_id int null,
pel_id int null
);

create table tbl_sucursales( 
suc_id int identity(1,1) not null,
cin_id int null,
suc_nom varchar(50) null,
suc_sec varchar(50) null,
suc_ruc varchar(50) null,
suc_dir varchar(50) null,
suc_tel int null,
suc_cor varchar(50) null,
suc_ciu varchar(50) null,
suc_esta varchar(50) null,
primary key(suc_id)
);

create table tbl_cine(
cin_id int identity(1,1) not null,
cin_nom varchar(50) null,
cin_est varchar(10) null,
primary key(cin_id)
);


create table tbl_sala(
sal_id int identity(1,1) not null,
sal_nom varchar(5) null,
sal_cap int null,
sal_esta varchar(20),
primary key(sal_id)
);

create table tbl_genero(
gen_id int identity(1,1) not null,
gen_nom varchar(60) null,
primary key(gen_id)
);

create table tbl_suc_pel(
suc_id int,
/*alter table tbl_suc_pel add sucp_est varchar(50) null;*/
pel_id int
);

create table tbl_empleado(
emp_id int identity(1,1) not null primary key,
emp_nom varchar(50) null,
emp_ape varchar(50) null,
emp_fnac varchar(50) null,
emp_freg varchar(50) null,
emp_dire varchar(50) null,
emp_tele varchar(10) null,
emp_cel varchar(10) null,
emp_ci varchar(10) null,
emp_est varchar(50) null
);

alter table tbl_emp_cin add constraint fk_emp_cin foreign key (emp_id) references tbl_empleado(emp_id);
alter table tbl_emp_cin add constraint fk_emp_cin2 foreign key (cin_id) references tbl_cine(cin_id);
alter table tbl_emp_cin add constraint fk_emp_cin3 foreign key (tip_emp) references tbl_tipo_empleado(tip_emp_id);

create table tbl_emp_cin(
emp_id int,
cin_id int,
tip_emp int
);

create table tbl_tipo_empleado(
tip_emp_id int identity(1,1) not null primary key,
tip__emp_nom varchar(50) null,
tip_emp_desc varchar(100) null,
tip_emp_est varchar(50) null
);
select * from tbl_usuario

alter table tbl_suc_pel add constraint fk_suc_peli foreign key(suc_id)
	references tbl_sucursales(suc_id);

alter table tbl_suc_pel add constraint fk_peli_suc foreign key(pel_id)
	references tbl_pelicula(pel_id);

alter table tbl_usuario add constraint fk_usu_cli foreign key(cli_id)
	references tbl_cliente(cli_id);

alter table tbl_usuario add constraint fk_usu_tipo foreign key(tus_id)
	references tbl_tipo_usuario(tus_id);

alter table tbl_suc_tar add constraint fk_suc_tar_suc foreign key(suc_id)
	references tbl_sucursales(suc_id);

alter table tbl_suc_tar add constraint fk_suc_tar_tar foreign key(tar_id)
	references tbl_tarifa(tar_id);

alter table tbl_tiket add constraint fk_tiket_usu foreign key(usu_id)
	references tbl_usuario(usu_id);

alter table tbl_tiket add constraint fk_tiket_pel foreign key(pel_id)
	references tbl_pelicula(pel_id);

alter table tbl_tiket add constraint fk_tiket_sal foreign key(sal_id)
	references tbl_sala(sal_id);

alter table tbl_tiket add constraint fk_tiket_tpag foreign key(tpag_id)
	references tbl_tipo_pago(tpag_id);

alter table tbl_tiket add constraint fk_tiket_tar foreign key(tar_id)
	references tbl_tarifa(tar_id);

alter table tbl_sucursales add constraint fk_suc_cin foreign key(cin_id)
	references tbl_cine(cin_id);

alter table tbl_hor_pel add constraint fk_hor_pel_pel foreign key(pel_id)
	references tbl_pelicula(pel_id);


alter table tbl_hor_pel add constraint fk_hor_pel_hor foreign key(hor_id)
	references tbl_horario(hor_id);

alter table tbl_sala_suc add constraint fk_sala_suc_sal foreign key(sal_id)
	references tbl_sala(sal_id);

alter table tbl_sala_suc add constraint fk_sala_suc_suc foreign key(suc_id)
	references tbl_sucursales(suc_id);

alter table tbl_gene_peli add constraint fk_gene_peli_gene foreign key(gen_id)
	references tbl_genero(gen_id);

alter table tbl_gene_peli add constraint fk_gene_peli_peli foreign key(pel_id)
	references tbl_pelicula(pel_id);

alter tbl_pelicula add 
	/*drop database statemovie*/

create proc mostrar_usuarios
as
select us.usu_id as 'ID Usuario',us.cli_id as 'ID Cliente',us.tus_id 'Tipo Usuario',us.usu_usu as 'Usuario',us.usu_pass as 'Password',us.usu_est as 'Estado' from tbl_usuario us where us.usu_id=us.usu_id 
go;

create proc mostrar_usuario_x_usuario
@usuario varchar(50)
as
select us.usu_id as 'ID Usuario',us.cli_id as 'ID Cliente',us.tus_id 'Tipo Usuario',us.usu_usu as 'Usuario',us.usu_pass as 'Password',us.usu_est as 'Estado' from tbl_usuario us where us.usu_id=us.usu_id and us.usu_usu=@usuario
go;

use statemovie;

execute mostrar_usuario_x_usuario 'adel';

alter table tbl_usuario add  usu_est varchar(50) null;


create proc crear_editar_usuario
@usu_id int,
@cli_id int,
@tus_id int,
@usuario varchar(100),
@contra varchar(100),
@estado varchar(50)
as
begin
	if(@usu_id =0)
		begin
		insert into tbl_usuario values (@cli_id,@tus_id,@usuario,@contra,@estado)
		end
	else
	begin
	update tbl_usuario set cli_id=@cli_id, tus_id=@tus_id,usu_usu=@usuario,usu_pass=@contra,usu_est=@estado where usu_id=@usu_id
	end
end
go;

drop proc crear_editar_usuario;

create proc eliminar_usuario
@usu_id int
as
update tbl_usuario set usu_est='i' where usu_id=@usu_id
go;

/*procesos de tipo usuario*/

create proc mostrar_tipos_usuarios
as
begin
select tip.tus_id as 'ID TIPO',tip.tus_desc as 'Descripcion' from tbl_tipo_usuario tip where tip.tus_id=tip.tus_id 
end
go;

create proc crear_tipo_usuario
@tusid int,
@desc varchar(50)
as
begin
insert into tbl_tipo_usuario values(@desc)
end
go;

create proc mostrar_pelicula
as
begin
select * from tbl_pelicula peli where peli.pel_id=peli.pel_id
end
go

alter table tbl_pelicula add pel_linkv varchar(100) null;
alter table tbl_pelicula add pel_linkba varchar(1000) null;
alter table tbl_pelicula alter column pel_est varchar(100) null;

create proc mostrar_pelicula_x_pelicula
@pel_nom varchar(50)
as
begin
select * from tbl_pelicula peli where peli.pel_id=peli.pel_id and pel_nom like @pel_nom
end
go

create proc crear_editar_pelicula
@pel_id int,
            @pel_nom varchar(50),
            @pel_pro varchar(50),
            @pel_dire varchar(50),
            @pel_cla varchar(50),
            @estado varchar(50),
            @pel_linkv varchar(100),
            @pel_linkba varchar(1000)
			as 
			begin 
			if(@pel_id =0)
		begin
		insert into tbl_pelicula values (@pel_nom,@pel_pro,@pel_dire,@pel_cla,@estado,@pel_linkv,@pel_linkba)
		end
	else
	begin
	update tbl_pelicula set pel_nom=@pel_nom,pel_pro=@pel_pro,pel_dire=@pel_dire,pel_cla=@pel_cla,pel_est=@estado,pel_linkv=@pel_linkv,pel_linkba=@pel_linkba where pel_id=@pel_id
	end
	end
	go

	create proc eliminar_pelicula
@pel_id int
    as
	begin 
	update tbl_pelicula set pel_est='deleted' where pel_id=@pel_id
	end
	go

/*Fin procesos Pelicula*/


/*Inicio procesos Cine*/
	create proc mostrar_cine
	as
	begin
	select * from tbl_cine c where c.cin_id=c.cin_id
	end
	go

create proc crear_editar_cine
@cin_id int,
            @cin_nom varchar(50),
            @cin_est varchar(50)
            as 
			begin 
			if(@cin_id =0)
		begin
		insert into tbl_cine values (@cin_nom,@cin_est)
		end
	else
	begin
	update tbl_cine set cin_nom=@cin_nom,cin_est=@cin_est  where cin_id=@cin_id
	end
	end
	go

	create proc eliminar_cine
	@cin_id int
	as
	begin
	update tbl_cine set cin_est='deleted' where cin_id=@cin_id
	end
	go
/*Fin procesos Cine*/


/*Inicio procesos Cliente*/
create proc mostrar_cliente
as
begin
select * from tbl_cliente cli where cli.cli_id=cli.cli_id
end
go

delete from tbl_cliente where cli_id=2
execute mostrar_cliente
create proc crear_editar_cliente
@cli_id int,
@cli_ruc varchar(13),
@cli_nom varchar(50),
@cli_ape varchar(50),
@cli_dire varchar(50),
@cli_tel int,
@cli_corr varchar(100),
@cli_fnaci varchar(50),
@cli_est varchar(50)
as 
begin 
if(@cli_id =0)
	begin
	 insert into tbl_cliente values (@cli_ruc,@cli_nom,@cli_ape,@cli_dire,@cli_tel,@cli_corr,@cli_fnaci,@cli_est)
	end
	else
	begin
	update tbl_cliente set cli_ruc=@cli_ruc,cli_nom=@cli_nom,cli_ape=@cli_ape,cli_dire=@cli_dire,cli_tel=@cli_tel,cli_corr=@cli_corr,cli_fnaci=@cli_fnaci,cli_est=@cli_est  where cli_id=@cli_id
	end
	end
	go

	create proc eliminar_cliente
	@cli_id int
	as
	begin
	update tbl_cliente set cli_est='deleted' where cli_id=@cli_id
	end
	go

/*Fin procesos Cliente*/

/*Inicio procesos Genero*/

create proc mostrar_generos
as
begin
select * from tbl_genero gr where gr.gen_id=gr.gen_id
end
go

create proc crear_editar_genero
@gen_id int,
@gen_nom varchar(60)
as 
begin 
if(@gen_id =0)
	begin
	 insert into tbl_genero values (@gen_nom)
	end
	else
	begin
	update tbl_genero set gen_nom=@gen_nom  where gen_id=@gen_id
	end
	end
	go




/*Fin procesos Genero*/






/*Inicio procesos Gpeli*/


create proc mostrar_todo_genypel
as
begin
select * from tbl_gene_peli gp where gp.gen_id=gp.gen_id and gp.pel_id=gp.pel_id
end
go

execute mostrar_genero_x_pel 'BATMAN: The Dark Knigth Returns'

create proc mostrar_genero_x_pel
@pel_nom varchar(50)
as
begin
select gen.* from tbl_pelicula pel,tbl_genero gen ,tbl_gene_peli gp where pel.pel_id=pel.pel_id and pel.pel_nom=@pel_nom and gp.pel_id=pel.pel_id and gp.gen_id=gen.gen_id and gen.gen_id=gen.gen_id order by gen.gen_id
end
go

/*Fin procesos Genero*/
alter table tbl_pelicula add pel_reg date null 

drop proc crear_tipo_usuario;

select * from tbl_tipo_usuario;

delete tbl_pelicula

select *from tbl_pelicula;

select * from tbl_usuario;

drop proc mostrar_usuario_x_usuario;

execute mostrar_usuarios;


DBCC CHECKIDENT (tbl_cliente, RESEED, 1);