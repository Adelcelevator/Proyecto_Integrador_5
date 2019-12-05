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

select * from tbl_usuario;
drop proc mostrar_usuario_x_usuario;
execute mostrar_usuarios;