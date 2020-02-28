package com.state.movie.statemovie.modelos;

import android.content.Context;
import android.util.Log;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.state.movie.statemovie.objetos.Variables;
import com.state.movie.statemovie.objetos.usuario;

import org.json.JSONObject;

import java.util.HashMap;

public class mod_usuario {
    usuario usu = new usuario();

    public String consulta(Context contexto, String valora) {
        final HashMap<String, Object> mapa = new HashMap<>();
        Variables vars = new Variables();
        String respuesta;
        final String url = "http://" + vars.getIp() + vars.getPuerto() + "/api/Usuario?usu_id=" + valora;
        Log.i("INFO", "CADENA DE CONEXION: " + url);
        RequestQueue res = Volley.newRequestQueue(contexto);
        StringRequest resq = new StringRequest(Request.Method.GET, url,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        Log.i("INFO", "ESTO ES LO QUE LLEGO: " + response);
                        mapa.put("respuesta", response);
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("Eroror", "VALIO GATO POR ESTO: " + error);
            }
        });
        res.add(resq);
        respuesta = (String) mapa.get("respuesta");
        Log.i("INFO", "LO QUE SE VA RETORNAR: " + respuesta);
        return respuesta;
    }
}
