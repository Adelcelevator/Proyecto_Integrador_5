package com.state.movie.statemovie;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import com.state.movie.statemovie.objetos.usuario;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {
    private Button btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btn = /*(Button)*/ findViewById(R.id.btn_prueba);
        getSupportActionBar().hide();
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    String dire = "http://192.168.1.21:51289/api/Usuario";
                    URL url = new URL(dire);
                    HttpURLConnection con = (HttpURLConnection) url.openConnection();
                    con.setRequestMethod("GET");
                    con.setRequestProperty("ACCEPT", "application/json");
                    if (con.getResponseCode() == 200) {
                        List<usuario> lista = new ArrayList<>();
                        lista.clear();
                        BufferedReader bfr = new BufferedReader(new InputStreamReader(con.getInputStream()));
                        String salida;
                        while ((salida = bfr.readLine()) != null) {
                            JSONArray json= new JSONArray(salida);
                            for (int i = 0; i<json.length(); i++) {
                                usuario usua = new usuario();
                                JSONObject jsn = json.getJSONObject(i);
                                usua.setUsu_id(jsn.getInt("usu_id"));
                                usua.setCli_id(jsn.getInt("cli_id"));
                                usua.setTus_id(jsn.getInt("tus_id"));
                                usua.setUsu_usu(jsn.getString("usu_usu"));
                                usua.setUsu_pass(jsn.getString("usu_pass"));
                                lista.add(usua);
                                Log.i("INFORMACION","TAMA========== "+lista.size());
                            }
                        }
                    }
                } catch (Exception e) {
                    Log.e("ERROR", "AQUI ES ESTO ======================== " + e);
                }
            }
        });

    }
}
