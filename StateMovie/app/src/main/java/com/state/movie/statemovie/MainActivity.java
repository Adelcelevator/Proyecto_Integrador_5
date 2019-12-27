package com.state.movie.statemovie;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.state.movie.statemovie.objetos.usuario;

import org.json.JSONObject;


public class MainActivity extends AppCompatActivity {
    public Button btn;
    public TextView txt_usuario;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btn = findViewById(R.id.btn_prueba);
        txt_usuario = findViewById(R.id.txt_usuario);
        try {
            getSupportActionBar().hide();
        } catch (Exception e) {
            Log.e("ERORR", "ERROR AL ESCONDER ESA COSA: " + e);
        }
        /*String ip = "172.21.104.22";
        String puerto = "51289";*/
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String ip = "172.21.104.22";
                String puerto = "51289";
                final String url = "http://" + ip + ":" + puerto + "/api/Usuario?usu_id=" + txt_usuario.getText().toString();
                Context contexto = getBaseContext();
                RequestQueue res = Volley.newRequestQueue(contexto);
                StringRequest resq = new StringRequest(Request.Method.GET, url,
                        new Response.Listener<String>() {
                            @Override
                            public void onResponse(String response) {
                                try {
                                    JSONObject json = new JSONObject((response.replace("]", "")).replace("[", ""));
                                    if (json.getInt("usu_id") != 0) {
                                        usuario usu = new usuario();
                                        usu.setUsu_id(json.getInt("usu_id"));
                                        usu.setCli_id(json.getInt("cli_id"));
                                        usu.setTus_id(json.getInt("tus_id"));
                                        usu.setUsu_usu(json.getString("usu_usu"));
                                        usu.setUsu_pass(json.getString("usu_pass"));
                                    } else {
                                        Log.i("INFO", "No Existe el Usuario");
                                    }
                                } catch (Exception e) {
                                    Log.e("error", "Error: " + e);
                                }
                            }
                        }, new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        Log.e("Eroror", "VALIO GATO POR ESTO: " + error);
                    }
                });
                res.add(resq);
            }
        });
    }
}
