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
public class ob_emp_us implements Serializable{

    private int usu_id, emp_id, tip_emp, cin_id;
    private String emp_usu, emp_us_contra, usu_emp_est;

    public int getUsu_id() {
        return usu_id;
    }

    public void setUsu_id(int usu_id) {
        this.usu_id = usu_id;
    }

    public int getEmp_id() {
        return emp_id;
    }

    public void setEmp_id(int emp_id) {
        this.emp_id = emp_id;
    }

    public int getTip_emp() {
        return tip_emp;
    }

    public void setTip_emp(int tip_emp) {
        this.tip_emp = tip_emp;
    }

    public int getCin_id() {
        return cin_id;
    }

    public void setCin_id(int cin_id) {
        this.cin_id = cin_id;
    }

    public String getEmp_usu() {
        return emp_usu;
    }

    public void setEmp_usu(String emp_usu) {
        this.emp_usu = emp_usu;
    }

    public String getEmp_us_contra() {
        return emp_us_contra;
    }

    public void setEmp_us_contra(String emp_us_contra) {
        this.emp_us_contra = emp_us_contra;
    }

    public String getUsu_emp_est() {
        return usu_emp_est;
    }

    public void setUsu_emp_est(String usu_emp_est) {
        this.usu_emp_est = usu_emp_est;
    }

    public ob_emp_us() {
    }

}
