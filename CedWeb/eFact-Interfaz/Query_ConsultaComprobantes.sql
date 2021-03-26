DECLARE @FechaDsd as Datetime 
DECLARE @FechaHst as Datetime 
SET @FechaDsd='20190901' 
SET @FechaHst='20190902' 

select gva12.id_gva12, gva12.cod_client, gva12.cat_iva, gva12.fecha_emis, gva12.n_comp, gva12.t_comp, gva12.cotiz, gva12.importe_iv, round(gva12.importe_iv * gva12.cotiz, 6) as importe_iv_pesos, gva12.unidades, gva12.importe, round((gva12.unidades - gva12.importe_iv) * gva12.cotiz, 6) as ImpTotalNetoGravado, gva12.pto_vta, gva12.leyenda_1, gva12.leyenda_2, gva12.leyenda_3, gva12.leyenda_4, gva12.leyenda_5, gva12.MON_CTE, 
gva14.c_postal, gva14.cod_provin, gva14.cuit, gva14.domicilio, gva14.localidad, gva14.nom_com, gva14.tipo_doc 
from GVA12 
inner join gva14 on gva12.cod_client=gva14.cod_client 
where fecha_emis >= @FechaDsd and fecha_emis < Dateadd (Day, 1, @FechaHst) 

select gva12.id_gva12, gva12.cod_client, gva12.cat_iva, gva12.fecha_emis, gva12.n_comp, gva12.t_comp, gva12.cotiz, gva12.importe_iv, gva12.unidades, gva12.importe, 
gva14.id_gva14, gva14.c_postal, gva14.cod_provin, gva14.cuit, gva14.domicilio, gva14.localidad, gva14.nom_com, gva14.tipo_doc, 
gva53.cantidad, gva53.id_medida_ventas, GVA53.PRECIO_NET, round(GVA53.PRECIO_NET * gva12.cotiz, 7) as PRECIO_NET_pesos, gva53.IMP_NETO_P, round(GVA53.IMP_NETO_P * gva12.cotiz, 6) as IMP_NETO_P_pesos, GVA53.PORC_IVA, 
sta11.descripcio, 
medida.cod_medida 
from GVA12 
inner join gva14 on gva12.cod_client=gva14.cod_client 
inner join gva53 on gva53.N_comp=gva12.n_comp and gva53.t_comp=gva12.t_comp 
inner join sta11 on gva53.COD_ARTICU=sta11.cod_articu 
inner join medida on gva53.ID_MEDIDA_VENTAS=medida.id_medida 
where fecha_emis >= @FechaDsd and fecha_emis < Dateadd (Day, 1, @FechaHst) 