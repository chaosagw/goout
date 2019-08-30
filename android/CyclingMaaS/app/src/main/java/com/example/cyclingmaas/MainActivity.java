package com.example.cyclingmaas;

import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;

public class MainActivity extends AppCompatActivity{
    // 選択肢
    private String spinnerItems[] = {" ","那覇空港", "瀬底島", "ブセナ海中公園", "美ら海水族館"};
    private String spinnerItems2[] = {" ","美ら海水族館", "瀬底島", "ブセナ海中公園", "那覇空港"};
    private String accessUrl = "http://arcg.is/1mDn9G";
    //private String accessUrl = "https://akira-watson.com/android/webview.html";

    //private TextView textView;

    @Override
    protected void onCreate(Bundle savedInstanceState){
            super.onCreate(savedInstanceState);
            setContentView(R.layout.activity_main);

            Button btn1 = findViewById(R.id.search_button);
            Button btn2 = findViewById(R.id.route_button);
            Button btn3 = findViewById(R.id.bike_button);
            Button btn4 = findViewById(R.id.pay_button);
            Spinner spinner1 = findViewById(R.id.spinner1);
            Spinner spinner2 = findViewById(R.id.spinner2);

            // ArrayAdapter
            ArrayAdapter<String> adapter
                    = new ArrayAdapter<>(this,
                    android.R.layout.simple_spinner_item, spinnerItems);

            adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

            ArrayAdapter<String> adapter2
                    = new ArrayAdapter<>(this,
                    android.R.layout.simple_spinner_item, spinnerItems2);

            adapter2.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            // spinner に adapter をセット
            spinner1.setAdapter(adapter);
            spinner2.setAdapter(adapter2);

            // リスナーを登録
            spinner1.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                //　アイテムが選択された時
                @Override
                public void onItemSelected(AdapterView<?> parent,
                                           View view, int position, long id) {
                    //Spinner spinner = (Spinner)parent;
                    //String item = (String)spinner.getSelectedItem();
                    //textView.setText(item);
                }

                //　アイテムが選択されなかった
                public void onNothingSelected(AdapterView<?> parent) {
                    //
                }
            });
            btn1.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                Uri uri = Uri.parse(accessUrl);
                Intent intent = new Intent(Intent.ACTION_VIEW,uri);
                startActivity(intent);
                overridePendingTransition(R.animator.activity_open_enter, R.animator.activity_open_exit);
                }
            });
            btn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplication(),RouteActivity.class);
                startActivity(intent);
                overridePendingTransition(R.animator.activity_open_enter, R.animator.activity_open_exit);
                }
            });
            btn3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplication(),ReserveActivity.class);
                startActivity(intent);
                overridePendingTransition(R.animator.activity_open_enter, R.animator.activity_open_exit);
            }
            });
        btn4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplication(),PaymentActivity.class);
                startActivity(intent);
                overridePendingTransition(R.animator.activity_open_enter, R.animator.activity_open_exit);
            }
        });

    }
}
