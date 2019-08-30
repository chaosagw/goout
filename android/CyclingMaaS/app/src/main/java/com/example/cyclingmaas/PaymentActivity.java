package com.example.cyclingmaas;

import android.media.AudioAttributes;
import android.media.AudioManager;
import android.media.SoundPool;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class PaymentActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_payment);
        setTitle("Payment page");

        // リスト項目のもととなる値を準備する
        String[] subjects = {"Bicycle Reservation　[6H]", "Bus　[Nago - Naha Terminal]", "Monorail　[Naha Terminal - Naha Airport]"};
        String[] comments = {"￥3,000", "￥800", "￥250"};
        ImageButton Ibtn1 = findViewById(R.id.imageButton);
        ImageButton Ibtn2 = findViewById(R.id.imageButton2);
        ImageButton Ibtn3 = findViewById(R.id.imageButton3);

        //音楽用のフィールドとSoundPoolのフィールド
        final int mp3a;
        final SoundPool soundPool;

        //soundPoolの初期化
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.LOLLIPOP) {

            //1個目のパラメーターはリソースの数に合わせる
            soundPool = new SoundPool(1, AudioManager.STREAM_MUSIC, 0);

        } else {
            AudioAttributes attr = new AudioAttributes.Builder()
                    .setUsage(AudioAttributes.USAGE_MEDIA)
                    .setContentType(AudioAttributes.CONTENT_TYPE_MUSIC)
                    .build();
            soundPool = new SoundPool.Builder()
                    .setAudioAttributes(attr)
                    //パラメーターはリソースの数に合わせる
                    .setMaxStreams(1)
                    .build();
        }
        //音楽の読み込み
        mp3a = soundPool.load(this, R.raw.decision4, 1);

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
        ListView paylist = findViewById(R.id.list_pay);
        paylist.setAdapter(adapter);

/*
        paylist.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                String Msg = "Payment finished";
                Toast.makeText(getApplicationContext(), Msg, Toast.LENGTH_LONG).show();
            }
        });
*/
        Ibtn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String Msg = "Payment finished";
                Toast.makeText(getApplicationContext(), Msg, Toast.LENGTH_SHORT).show();
                soundPool.play(mp3a,1f , 1f, 0, 0, 1f);
            }
        });
        Ibtn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String Msg = "Payment finished";
                Toast.makeText(getApplicationContext(), Msg, Toast.LENGTH_SHORT).show();
                soundPool.play(mp3a,1f , 1f, 0, 0, 1f);
            }
        });
        Ibtn3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String Msg = "Payment finished";
                Toast.makeText(getApplicationContext(), Msg, Toast.LENGTH_SHORT).show();
                soundPool.play(mp3a,1f , 1f, 0, 0, 1f);
            }
        });

    }
    @Override
    public void finish(){
        super.finish();
        overridePendingTransition(R.animator.activity_close_enter, R.animator.activity_close_exit);
    }
}
