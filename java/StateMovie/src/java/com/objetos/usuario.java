/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.objetos;

/**
 *
 * @author Panchito
 */
public class usuario {
    private int usu_id,cli_id,tus_id;
    private String usu_usu,usu_pass;

    public usuario() {
    }

    public int getUsu_id() {
        return usu_id;
    }

    public void setUsu_id(int usu_id) {
        this.usu_id = usu_id;
    }

    public int getCli_id() {
        return cli_id;
    }

    public void setCli_id(int cli_id) {
        this.cli_id = cli_id;
    }

    public int getTus_id() {
        return tus_id;
    }

    public void setTus_id(int tus_id) {
        this.tus_id = tus_id;
    }

    public String getUsu_usu() {
        return usu_usu;
    }

    public void setUsu_usu(String usu_usu) {
        this.usu_usu = usu_usu;
    }

    public String getUsu_pass() {
        return usu_pass;
    }

    public void setUsu_pass(String usu_pass) {
        this.usu_pass = usu_pass;
    }
    
}
