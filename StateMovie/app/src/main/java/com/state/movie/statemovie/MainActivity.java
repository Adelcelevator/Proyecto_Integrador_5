package com.state.movie.statemovie;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.state.movie.statemovie.modelos.mod_usuario;
import com.state.movie.statemovie.objetos.usuario;


public class MainActivity extends AppCompatActivity {
    public Button btn;
    public TextView txt_usuario;
    mod_usuario musu = new mod_usuario();
    usuario obus = new usuario();



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
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String respuesta = musu.consulta(getBaseContext(),txt_usuario.getText().toString());
                Log.i("INFO","LLEGO ESTO: "+respuesta);
            }
        });
    }
}
