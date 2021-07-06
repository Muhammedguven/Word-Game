using System;
using System.Collections.Generic;
using System.Linq;
using TranslateApplication.Helpers;
using TranslateApplication.LevelWords;
using TranslateApplication.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TranslateApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        ApiService api;
        WordList words;
        Effects effect;
        int level = 1;
        public SearchPage()
        {
            InitializeComponent();
            highScore.Text = "En yüksek puan: "+ Preferences.Get("HighScore", "0").ToString();
            api = new ApiService();
            words = new WordList();
            effect = new Effects();
        }
        public void DogruCevap()
        {
            point.Text = (Convert.ToInt32(point.Text) + level).ToString();
            resultText.Text = "Doğru Cevap";
            resultText.TextColor = Color.FromHex("A5EB78");
            effect.trueEffect(resultText);
            effect.trueEffect(point);
        }
        public void YanlisCevap()
        {
            point.Text = (Convert.ToInt32(point.Text) - level).ToString();
            resultText.Text = "Yanlış Cevap";
            resultText.TextColor = Color.FromHex("f54748");
            effect.falseEffect(resultText);
            effect.falseEffect(point);

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(searchWord.Text))
            {
                var result = await api.GetWordAsync(searchWord.Text.ToLower(), "en", "tr");
                var resultTdk = await api.GetDetailAsync(questionWord.Text);//Belli bir requestten sonra ücretli olduğu için hata veriyor.

                if (result.code == 200)
                {
                    if (result.text[0] == questionWord.Text)
                    {
                        DogruCevap();
                    }
                    else
                    {
                        YanlisCevap();
                    }
                    
                    if (resultTdk.success != "false")
                    {
                        word.Text = questionWord.Text + " ilk anlamı:";
                        anlamDetail.Text = resultTdk.result[0].madde.kelime[0].anlam;
                        searchWord.Text = null;
                    }
                    
                }
                else
                {
                    await DisplayAlert("Hata", "Bağlantı gitti!", "Tamam");
                }
                NextWord();
            }
            if (Convert.ToInt32(point.Text) > Convert.ToInt32(Preferences.Get("HighScore", "0")))
            {
                Preferences.Set("HighScore", point.Text);
                highScore.Text = "En yüksek puan: " + Preferences.Get("HighScore", "0").ToString();
                effect.falseEffect(highScore);
            }
            
        }
        public async void NextWord()
        {
            if (words.usedWords.Count() < words.allWords.Count())
            {
                effect.sliderEffect(questionWord);
                Words word = words.getRandom();
                level = word.Level;
                seviye.Text = "Seviye " + level;
                questionWord.Text = word.Word;

            }
            else
            {
                var action = await DisplayAlert("Oyun Bitti", "Tebrikler " + point.Text + " puan topladınız!!!", "Yeniden Oyna", "Tamam");
                button.IsVisible = false;
                if (action)
                {
                    App.Current.MainPage = new SearchPage();
                }
            }
        }

    }
}