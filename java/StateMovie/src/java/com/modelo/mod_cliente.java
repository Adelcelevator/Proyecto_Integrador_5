/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.modelo;

import com.objetos.ob_cliente;
import com.vari.Variables;

/**
 *
 * @author Panchito
 */
public class mod_cliente {

    private Variables vars = new Variables();

    public boolean registrar(ob_cliente nuevo) {
        try {
            String werl = "http://" + vars.getIp() + vars.getPuertp() + "/api/Cliente?ruc=" + nuevo.getCli_ruc() + "&nom=" + nuevo.getCli_nom() + "&ape=" + nuevo.getCli_ape() + "&dire=" + nuevo.getCli_dire() + "&tel=" + nuevo.getCli_tel() + "&corr=" + nuevo.getCli_corr() + "&fnaci=" + nuevo.getCli_fnaci() + "&est=activo";
            System.out.println("SALIDA DEL NUEOV CLI: "+werl);
            return false;
        } catch (Exception e) {
            return false;
        }
    }
}
