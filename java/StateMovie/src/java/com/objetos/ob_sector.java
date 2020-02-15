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
public class ob_sector {
    private int sec_id,ciu_id;
    private String sec_nom,sec_est;

    public int getSec_id() {
        return sec_id;
    }

    public void setSec_id(int sec_id) {
        this.sec_id = sec_id;
    }

    public int getCiu_id() {
        return ciu_id;
    }

    public void setCiu_id(int ciu_id) {
        this.ciu_id = ciu_id;
    }

    public String getSec_nom() {
        return sec_nom;
    }

    public void setSec_nom(String sec_nom) {
        this.sec_nom = sec_nom;
    }

    public String getSec_est() {
        return sec_est;
    }

    public void setSec_est(String sec_est) {
        this.sec_est = sec_est;
    }

    public ob_sector() {
    }
    
}
