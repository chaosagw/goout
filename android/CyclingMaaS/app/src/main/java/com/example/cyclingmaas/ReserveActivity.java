package com.example.cyclingmaas;

import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class ReserveActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reserve);
        setTitle("Reservation page");

        // リスト項目のもととなる値を準備する
        String[] subjects = {"Nago-ichiba Rental Cycle", "Noleggio cicli", "HUBCYCLE OKINAWA", "FUKU Rental Cycle","NAMIKI Rental Cycle"};
        String[] comments = {"[Road bike：5　Cross bike：3]", "[Road bike：2　Cross bike：1]", "[Road bike：3　Cross bike：3]", "[Electric assist bike：5　Cross bike：1]","[Cross bike：3]"};


        // ListViewに表示するリスト項目をArrayListで準備する
        List<Map<String, String>> data = new ArrayList<Map<String, String>>();
        for (int i=0; i<subjects.length; i++){
            Map<String, String> item = new HashMap<String, String>();
            item.put("Subject", subjects[i]);
            item.put("Comment", comments[i]);
            data.add(item);
        }

        // リスト項目とListViewを対応付けるArrayAdapterを用意する
        SimpleAdapter adapter = new SimpleAdapter(this, data,
                android.R.layout.simple_list_item_2,
                new String[] { "Subject", "Comment" },
                new int[] { android.R.id.text1, android.R.id.text2});

        // ListViewにArrayAdapterを設定する
        ListView listView = findViewById(R.id.listView);
        listView.setAdapter(adapter);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                Intent intent = new Intent(getApplication(),FormActivity.class);
                startActivity(intent);
                overridePendingTransition(R.animator.activity_open_enter, R.animator.activity_open_exit);
            }
        });
        listView.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {

                String str_url;
                Uri uri;
                Intent intent;

                switch(position){
                    case 0:
                        str_url = "https://nagomun.or.jp/info/2861/";
                        uri = Uri.parse(str_url);
                        intent = new Intent(Intent.ACTION_VIEW,uri);
                        startActivity(intent);
                        break;
                    case 1:
                        str_url = "https://www.noleggio-cicli.blue/";
                        uri = Uri.parse(str_url);
                        intent = new Intent(Intent.ACTION_VIEW,uri);
                        startActivity(intent);
                        break;
                    case 2:
                        str_url = "https://www.hubcycleokinawa.com/rental-bicycle";
                        uri = Uri.parse(str_url);
                        intent = new Intent(Intent.ACTION_VIEW,uri);
                        startActivity(intent);
                        break;
                    case 3:
                        str_url = "https://www.fukugi-namiki.com/renta.html";
                        uri = Uri.parse(str_url);
                        intent = new Intent(Intent.ACTION_VIEW,uri);
                        startActivity(intent);
                        break;
                    case 4:
                        str_url = "http://namikir.web.fc2.com/";
                        uri = Uri.parse(str_url);
                        intent = new Intent(Intent.ACTION_VIEW,uri);
                        startActivity(intent);
                        break;
                }

                return false;


            }

        });
    }
    @Override
    public void finish(){
        super.finish();
        overridePendingTransition(R.animator.activity_close_enter, R.animator.activity_close_exit);
    }
}
