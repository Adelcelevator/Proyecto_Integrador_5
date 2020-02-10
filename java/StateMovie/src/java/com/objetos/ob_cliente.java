/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.objetos;

import java.io.Serializable;

/**
 *
 * @author Panchito
 */
public class ob_cliente implements Serializable{

    private int cli_id;
    private String cli_ruc, cli_nom, cli_ape, cli_dire, cli_tel, cli_corr, cli_fnaci, cli_est;

    public int getCli_id() {
        return cli_id;
    }

    public void setCli_id(int cli_id) {
        this.cli_id = cli_id;
    }

    public String getCli_ruc() {
        return cli_ruc;
    }

    public void setCli_ruc(String cli_ruc) {
        this.cli_ruc = cli_ruc;
    }

    public String getCli_nom() {
        return cli_nom;
    }

    public void setCli_nom(String cli_nom) {
        this.cli_nom = cli_nom;
    }

    public String getCli_ape() {
        return cli_ape;
    }

    public void setCli_ape(String cli_ape) {
        this.cli_ape = cli_ape;
    }

    public String getCli_dire() {
        return cli_dire;
    }

    public void setCli_dire(String cli_dire) {
        this.cli_dire = cli_dire;
    }

    public String getCli_tel() {
        return cli_tel;
    }

    public void setCli_tel(String cli_tel) {
        this.cli_tel = cli_tel;
    }

    public String getCli_corr() {
        return cli_corr;
    }

    public void setCli_corr(String cli_corr) {
        this.cli_corr = cli_corr;
    }

    public String getCli_fnaci() {
        return cli_fnaci;
    }

    public void setCli_fnaci(String cli_fnaci) {
        this.cli_fnaci = cli_fnaci;
    }

    public String getCli_est() {
        return cli_est;
    }

    public void setCli_est(String cli_est) {
        this.cli_est = cli_est;
    }

    public ob_cliente() {
    }
}
