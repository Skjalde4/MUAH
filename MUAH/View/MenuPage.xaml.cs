using System;
using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
using System.Linq;
//using System.Runtime.InteropServices.WindowsRuntime;
//using Windows.Foundation;
//using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
//using Windows.UI.Xaml.Controls.Primitives;
//using Windows.UI.Xaml.Data;
//using Windows.UI.Xaml.Input;
//using Windows.UI.Xaml.Media;
//using Windows.UI.Xaml.Media.Animation;
//using Windows.UI.Xaml.Navigation;
using MUAH.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUAH.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {

        List<CustomerSession> session = new List<CustomerSession>();
        private int LocalSessionId = 0;
        private static Guid CustomerGuid = Guid.NewGuid();


        private int productId;

        #region Forret product id

        private const int forretHvidvinslaks = 1;
        private const int forretVarmrøgetlaks = 2;
        private const int forretCapaccio = 3;
        private const int forretLakseroulade = 4;
        private const int forretTunmousse = 5;
        private const int forretSeranoskine = 6;
        private const int forretLaksemousse = 7;

        #endregion

        #region Hovedret product id

        private const int hovedretKalveculotte = 8;
        private const int hovedretOksefilet = 9;
        private const int hovedretFlæskesteg = 10;
        private const int hovedretKylligefilet = 11;
        private const int hovedretGlaseretSkinke = 12;
        private const int hovedretLaksesteak = 13;
        private const int hovedretKalvesteg = 14;
        private const int hovedretLammekølle = 15;

        #endregion

        #region Dessert product id

        private const int dessertÆblekage = 16;
        private const int dessertChokolademousse = 17;
        private const int dessertPassionsmousse = 18;
        private const int dessertSkovbærtærte = 19;
        private const int dessertFriskFrugt = 20;
        private const int dessertHindbærmousse = 21;
        private const int dessertChokoladekage = 22;
        private const int dessertBlåbærCheesecake = 23;

        #endregion

        #region Salat product id

        private const int salatBroccolisalat = 24;
        private const int salatGrønsalat = 25;
        private const int salatTomatsalat = 26;
        private const int salatPastasalat = 27;

        #endregion

        #region Smørrebrød rugbrød product id

        private const int smørrebrødHåndmadderUspecificeretR = 28;
        private const int smørrebrødHåndmadderSpecificeretR = 29;
        private const int smørrebrødHøjtbelagtUspecificeretR = 30;
        private const int smørrebrødÆgTomatR = 31;
        private const int smørrebrødÆgRejerR = 32;
        private const int smørrebrødRullepølseR = 33;
        private const int smørrebrødFrikadelleR = 34;
        private const int smørrebrødFlæskestegR = 35;
        private const int smørrebrødLeverpostejR = 36;
        private const int smørrebrødDyrlægensR = 37;
        private const int smørrebrødRoastbeefR = 38;
        private const int smørrebrødFiskefiletR = 39;
        private const int smørrebrødStjernekasterR = 40;
        private const int smørrebrødStjerneskudR = 41;
        private const int smørrebrødSkinkeR = 42;
        private const int smørrebrødOksebrystR = 43;
        private const int smørrebrødKalkunR = 44;
        private const int smørrebrødTatarR = 45;
        private const int smørrebrødMørbradbøfR = 46;
        private const int smørrebrødBrieR = 47;
        private const int smørrebrødMellemlageretR = 48;
        private const int smørrebrødLageretR = 49;
        
        #endregion

        

        #region Smørrebrød franskbrød product id

        private const int smørrebrødHåndmadderUspecificeretF = 50;
        private const int smørrebrødHåndmadderSpecificeretF = 51;
        private const int smørrebrødHøjtbelagtUspecificeretF = 51;
        private const int smørrebrødÆgTomatF = 53;
        private const int smørrebrødÆgRejerF = 54;
        private const int smørrebrødRullepølseF = 55;
        private const int smørrebrødFrikadelleF = 56;
        private const int smørrebrødFlæskestegF = 57;
        private const int smørrebrødLeverpostejF = 58;
        private const int smørrebrødDyrlægensF = 59;
        private const int smørrebrødRoastbeefF = 60;
        private const int smørrebrødFiskefiletF = 61;
        private const int smørrebrødStjernekasterF = 62;
        private const int smørrebrødStjerneskudF = 63;
        private const int smørrebrødSkinkeF = 64;
        private const int smørrebrødOksebrystF = 65;
        private const int smørrebrødKalkunF = 66;
        private const int smørrebrødTatarF = 67;
        private const int smørrebrødMørbradbøfF = 68;
        private const int smørrebrødBrieF = 69;
        private const int smørrebrødMellemlageretF = 70;
        private const int smørrebrødLageretF = 71;

        #endregion

        #region Koldtbord product id

        private const int koldtbord = 72;
        private const int koldtbordPlatte = 73;
        private const int koldtbordLuksusPlatte = 74;

        #endregion

        #region Sandwich product id
        
        private const int sandwichKylling = 75;
        private const int sandwichÆgBacon = 76;
        private const int sandwichRoastbeef = 77;
        private const int sandwichSteg = 78;
        private const int sandwichFrikadelle = 79;
        private const int sandwichSkinkeOst = 80;
        private const int sandwichRøgetLaks = 81;
        private const int sandwichÆgRejer = 82;
        private const int sandwichTunsalat = 83;
        private const int sandwichSerano = 84;
        
        #endregion

        #region Checkbox metoder i buffet

        private void CheckMeet()
        {
            List<CheckBox> checkboxes = new List<CheckBox>(){chkHvidvinsLaks, chkOksefilet, chkGlaseretSkinke, chkSvinekam, chkKyllingefilet, chkLammekølle, chkFrikadeller, chkKalveculotte, chkAndebryst};

            int numberChecked = checkboxes.Where(x => x.IsChecked == true).ToList().Count();

            foreach (var cb in checkboxes)
            {
                if (numberChecked < 2 || cb.IsChecked == true)
                    cb.IsEnabled = true;
                else
                    cb.IsEnabled = false;
            }
        }

        private void CheckSalad()
        {
            List<CheckBox> checkboxes = new List<CheckBox>(){chkGrønsalatBuffet, chkBroccolisalatBuffet, chkBulgursalatBuffet, chkPastasalatBuffet, chkRodfrugterBuffet, chkTomatsalatBuffet};

            int numberChecked = checkboxes.Where(x => x.IsChecked == true).ToList().Count();

            foreach (var cb in checkboxes)
            {
                if (numberChecked < 2 || cb.IsChecked == true)
                    cb.IsEnabled = true;
                else
                    cb.IsEnabled = false;
            }
        }

        private void CheckPotato()
        {
            List<CheckBox> checkboxes = new List<CheckBox>() { chkFlødekartofler, chkBagtKartoffel, chkKartoffelsalat, chkTimianKartofler, chkSmørstegteKartofler, chkKogteKartofler };

            int numberChecked = checkboxes.Where(x => x.IsChecked == true).ToList().Count();

            foreach (var cb in checkboxes)
            {
                if (numberChecked < 1 || cb.IsChecked == true)
                    cb.IsEnabled = true;
                else
                    cb.IsEnabled = false;
            }
        }

        private void CheckSauce()
        {
            List<CheckBox> checboxes = new List<CheckBox>(){chkBearnaise, chkRødvindssauce, chkSkysauce, chkHollandaise, ChkDressing};

            int numberChecked = checboxes.Where(x => x.IsChecked == true).ToString().Count();

            foreach (var cb in checboxes)
            {
                if (numberChecked < 1 || cb.IsChecked == true)
                    cb.IsEnabled = true;

                else
                    cb.IsEnabled = false;
            }
        }

        #endregion

        public MenuPage()
        {
            this.InitializeComponent();
        }
        #region Add To session List metoder

        private void BuffetToList()
        {

        }
        
        private void OrderToList(bool myOperator, int ProductId, string ProductName, double ProductPrice, int NoOfProduct)
        {
            bool productExist = false;

            //check om brugerne har tilføjet en vare
            if (session.Count > 0)
            {
                // finde den vare som findes i forvejen og hvis den er skal denne vare så + eller -
                foreach (var product in session)
                {
                    if (product.ProductId == ProductId)
                    {
                        if (myOperator)
                            product.NoOfProduct++;
                        else
                            product.NoOfProduct--;

                        // når productExist er true, så bliver listen ikke addet et nyt item - der bliver addet et nyt item til det allerede eksisterende productId
                        productExist = true;
                    }
                }
            }
            if (!productExist)
            {
                session.Add(new CustomerSession());
                session[LocalSessionId].SessionId = CustomerGuid;
                session[LocalSessionId].ProductId = ProductId;
                session[LocalSessionId].ProductName = ProductName;
                session[LocalSessionId].ProductPrice = ProductPrice;
                session[LocalSessionId].NoOfProduct = NoOfProduct;

                LocalSessionId++;
            }
        }

        #endregion


        private string addAntal(string txtAntal)
        {
            int antal = Convert.ToInt32(txtAntal);

            antal++;

            return antal.ToString();
        }

        private string subAntal(string txtAntal)
        {
            int antal = Convert.ToInt32(txtAntal);
            if (antal > 0)
            {
                antal--;
            }

            session.Remove(new CustomerSession());

            return antal.ToString();
        }

        #region Grid loading

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            HidePanels(null);
            pnlBackGround.Visibility = Visibility.Collapsed;

            imgBrunch.Visibility = Visibility.Visible;
            imgBuffet.Visibility = Visibility.Visible;
            imgFrokost.Visibility = Visibility.Visible;
            imgKoldtbord.Visibility = Visibility.Visible;
            imgSmørrebrød.Visibility = Visibility.Visible;
            imgTapas.Visibility = Visibility.Visible;

            
        }

        #endregion

        private void BtnRetur_Click(object sender, RoutedEventArgs e)
        {
            ((Frame) Window.Current.Content).Navigate(typeof(SpecificStore));
        }

        #region HidePanels

        private void HidePanels(RelativePanel myPanel)
        {
            List<RelativePanel> myPanels = new List<RelativePanel>();

            myPanels.Add(pnlSmørrebrød);
            myPanels.Add(pnlDessert);
            myPanels.Add(pnlHovedret);
            myPanels.Add(pnlForret);
            myPanels.Add(pnlBuffet);
            myPanels.Add(pnlTapas);
            myPanels.Add(pnlBrunch);
            myPanels.Add(pnlSandwich);
            myPanels.Add(pnlSpecials);
            myPanels.Add(pnlKoldtbord);
            myPanels.Add(pnlSalater);


            if (myPanel != null)
            {
                myPanels.Remove(myPanel);
                pnlBackGround.Visibility = Visibility.Visible;
                myPanel.Visibility = Visibility.Visible;

                imgBrunch.Visibility = Visibility.Collapsed;
                imgBuffet.Visibility = Visibility.Collapsed;
                imgFrokost.Visibility = Visibility.Collapsed;
                imgKoldtbord.Visibility = Visibility.Collapsed;
                imgSmørrebrød.Visibility = Visibility.Collapsed;
                imgTapas.Visibility = Visibility.Collapsed;

            }

            foreach (var items in myPanels)
            {
                items.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnSmørrebrød_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlSmørrebrød);
        }

        private void BtnDessert_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlDessert);
        }

        private void BtnForret_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlForret);
        }

        private void BtnHovedret_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlHovedret);
        }

        private void BtnBrunch_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlBrunch);
        }

        private void BtnTapas_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlTapas);
        }

        private void BtnSalater_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlSalater);
        }

        private void BtnSandwich_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlSandwich);
        }

        private void BtnKoldtbord_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlKoldtbord);
        }

        private void BtnSpecials_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlSpecials);
        }

        private void BtnBuffet_Click_1(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlBuffet);
        }

        #endregion     

        #region SmørrebrødToListRugbrød

        private void BtnPlusHåndmadderUspecificeretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHåndmadderUspecificeretRugbrød.Text = addAntal(txtAntalHåndmadderUspecificeretRugbrød.Text);
            OrderToList(true, smørrebrødHåndmadderUspecificeretR, txtHåndmadderUspecificeret.Text, Convert.ToDouble(txtHåndmadderUspecificeretPris.Text), Convert.ToInt32(txtAntalHåndmadderUspecificeretRugbrød.Text));
        }

        private void BtnMinusHåndmadderUspecificeretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHåndmadderUspecificeretRugbrød.Text = subAntal(txtAntalHåndmadderUspecificeretRugbrød.Text);
            OrderToList(false, smørrebrødHåndmadderUspecificeretR, txtHåndmadderUspecificeret.Text, Convert.ToDouble(txtHåndmadderUspecificeretPris.Text), Convert.ToInt32(txtAntalHåndmadderUspecificeretRugbrød.Text));
        }


        private void BtnPlusHåndmadderSpecificeretRugbrød_Click(object sender, RoutedEventArgs e)
        {
             txtAntalHåndmadderSpecificeretRugbrød.Text = addAntal(txtAntalHåndmadderSpecificeretRugbrød.Text);
        }

        private void BtnMinusHåndmadderSpecificeretRugbrød_Click(object sender, RoutedEventArgs e)
        {
              txtAntalHåndmadderSpecificeretRugbrød.Text = subAntal(txtAntalHåndmadderSpecificeretRugbrød.Text);
        }

        private void BtnPlusHøjtbelagtRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHøjbelagtRugbrød.Text = addAntal(txtAntalHøjbelagtRugbrød.Text);
        }

        private void BtnMinusHøjtbelagtRugbrød_Click(object sender, RoutedEventArgs e)
        {
              txtAntalHøjbelagtRugbrød.Text = subAntal(txtAntalHøjbelagtRugbrød.Text);
        }

        private void BtnPlusÆgTomatRugbrød_Click(object sender, RoutedEventArgs e)
        {
              txtAntalÆgTomatRugbrød.Text = addAntal(txtAntalÆgTomatRugbrød.Text);
        }

        private void BtnMinusÆgTomatRugbrød_Click(object sender, RoutedEventArgs e)
        {
             txtAntalÆgTomatRugbrød.Text = subAntal(txtAntalÆgTomatRugbrød.Text);
        }

        private void BtnPlusÆgRejerRugbrød_Click(object sender, RoutedEventArgs e)
        {
             txtAntalÆgRejerRugbrød.Text = addAntal(txtAntalÆgRejerRugbrød.Text);
        }

        private void BtnMinusÆgRejerRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆgRejerRugbrød.Text = subAntal(txtAntalÆgRejerRugbrød.Text);
        }

        private void BtnPlusRullepølseRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRullepølseRugbrød.Text = addAntal(txtAntalRullepølseRugbrød.Text);
        }

        private void BtnMinusRullepølseRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRullepølseRugbrød.Text = subAntal(txtAntalRullepølseRugbrød.Text);
        }

        private void BtnPlusFrikadelleRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFrikadelleRugbrød.Text = addAntal(txtAntalFrikadelleRugbrød.Text);
        }

        private void BtnMinusFrikadlleRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFrikadelleRugbrød.Text = subAntal(txtAntalFrikadelleRugbrød.Text);
        }

        private void BtnPlusFlæskestegRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFlæskestegRgbrød.Text = addAntal(txtAntalFlæskestegRgbrød.Text);
        }

        private void BtnMinusFlæskestegRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFlæskestegRgbrød.Text = subAntal(txtAntalFlæskestegRgbrød.Text);
        }

        private void BtnPlusLeverpostejRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLeverposteRugbrød.Text = addAntal(txtAntalLeverposteRugbrød.Text);
        }

        private void BtnMinusLeverpostejRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLeverposteRugbrød.Text = subAntal(txtAntalLeverposteRugbrød.Text);
        }

        private void BtnPlusDyrlægensRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalDyrlægensRugbrød.Text = addAntal(txtAntalDyrlægensRugbrød.Text);
        }

        private void BtnMinusDyrlægensRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalDyrlægensRugbrød.Text = subAntal(txtAntalDyrlægensRugbrød.Text);
        }

        private void BtnPlusRoastbeefRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRoastbeefRugbrød.Text = addAntal(txtAntalRoastbeefRugbrød.Text);
        }

        private void BtnMinusRoastbeefRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRoastbeefRugbrød.Text = subAntal(txtAntalRoastbeefRugbrød.Text);
        }

        private void BtnPlusFiskefiletRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFiskefiletRugbrød.Text = addAntal(txtAntalFiskefiletRugbrød.Text);
        }

        private void BtnMinusFiskefiletRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFiskefiletRugbrød.Text = subAntal(txtAntalFiskefiletRugbrød.Text);
        }

        private void BtnPlusStjernekasterRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStjernekasterRugbrød.Text = addAntal(txtAntalStjernekasterRugbrød.Text);
        }

        private void BtnMinusStjernekasterRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStjernekasterRugbrød.Text = subAntal(txtAntalStjernekasterRugbrød.Text);
        }

        private void BtnPlusStjerneskudRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStjerneskudRugbrød.Text = addAntal(txtAntalStjerneskudRugbrød.Text);
        }

        private void BtnMinusStjerneskudRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStjerneskudRugbrød.Text = subAntal(txtAntalStjerneskudRugbrød.Text);
        }

        private void BtnPlusSkinkeRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSkinkeRugbrød.Text = addAntal(txtAntalSkinkeRugbrød.Text);
        }

        private void BtnMinusSkinkeRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSkinkeRugbrød.Text = subAntal(txtAntalSkinkeRugbrød.Text);
        }

        private void BtnPlusOksebrystRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalOksebrystRugbrød.Text = addAntal(txtAntalOksebrystRugbrød.Text);
        }

        private void BtnMinusOksebrystRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalOksebrystRugbrød.Text = subAntal(txtAntalOksebrystRugbrød.Text);
        }

        private void BtnPlusKalkunRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKalkunRugbrød.Text = addAntal(txtAntalKalkunRugbrød.Text);
        }

        private void BtnMinusKalkunRugbrød_Click(object sender, RoutedEventArgs e)
        {
             txtAntalKalkunRugbrød.Text = subAntal(txtAntalKalkunRugbrød.Text);
        }

        private void BtnPlusTatarRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTatarRugbrød.Text = addAntal(txtAntalTatarRugbrød.Text);
        }

        private void BtnMinusTatarRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTatarRugbrød.Text = subAntal(txtAntalTatarRugbrød.Text);
        }

        private void BtnPlusMørbradRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMørbradRugbrød.Text = addAntal(txtAntalMørbradRugbrød.Text);
        }

        private void BtnMinusMørbradRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMørbradRugbrød.Text = subAntal(txtAntalMørbradRugbrød.Text);
        }

        private void BtnPlusBrieRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalBrieRugbrød.Text = addAntal(txtAntalBrieRugbrød.Text);
        }

        private void BtnMinusBrieRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalBrieRugbrød.Text = subAntal(txtAntalBrieRugbrød.Text);
        }

        private void BtnPlusMellemlageretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMellemlageretRugbrød.Text = addAntal(txtAntalMellemlageretRugbrød.Text);
        }

        private void BtnMinusMellemlageretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMellemlageretRugbrød.Text = subAntal(txtAntalMellemlageretRugbrød.Text);
        }

        private void BtnPlusLageretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLageretRugbrød.Text = addAntal(txtAntalLageretRugbrød.Text);
        }

        private void BtnMinusLageretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLageretRugbrød.Text = subAntal(txtAntalLageretRugbrød.Text);
        }

        #endregion

        #region Plus/Minus smørrebrød franskbrød

        private void BtnPlusHåndmadderUspecificeretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHåndmadderUspecificeretFranskbrød.Text = addAntal(txtAntalHåndmadderUspecificeretFranskbrød.Text);
        }

        private void BtnMinusHåndmadderUspecificeretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHåndmadderUspecificeretFranskbrød.Text = subAntal(txtAntalHåndmadderUspecificeretFranskbrød.Text);
        }

        private void BtnPlusHåndmadderSpecificeretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHåndmadderSpecificeretFranskbrød.Text = addAntal(txtAntalHåndmadderSpecificeretFranskbrød.Text);
        }

        private void BtnMinusHåndmadderSpecificeretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHåndmadderSpecificeretFranskbrød.Text = subAntal(txtAntalHåndmadderSpecificeretFranskbrød.Text);
        }

        private void BtnPlusHøjtbelagtFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHøjtbelagtFranskbrød.Text = addAntal(txtAntalHøjtbelagtFranskbrød.Text);
        }

        private void BtnMinusHøjtbelagtFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHøjtbelagtFranskbrød.Text = subAntal(txtAntalHøjtbelagtFranskbrød.Text);
        }

        private void BtnPlusÆgTomatFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆgTomatFranskbrød.Text = addAntal(txtAntalÆgTomatFranskbrød.Text);
        }

        private void BtnMinusÆgTomatFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆgTomatFranskbrød.Text = subAntal(txtAntalÆgTomatFranskbrød.Text);
        }

        private void BtnPlusÆgRejerFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆgRejerFranskbrød.Text = addAntal(txtAntalÆgRejerFranskbrød.Text);
        }

        private void BtnMinusÆgRejerFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆgRejerFranskbrød.Text = subAntal(txtAntalÆgRejerFranskbrød.Text);
        }

        private void BtnPlusRullepølseFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRullepølseFranskbrød.Text = addAntal(txtAntalRullepølseFranskbrød.Text);
        }

        private void BtnMinusRullepølseFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRullepølseFranskbrød.Text = subAntal(txtAntalRullepølseFranskbrød.Text);
        }

        private void BtnPlusFrikadelleFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFrikadelleFranskbrød.Text = addAntal(txtAntalFrikadelleFranskbrød.Text);
        }

        private void BtnMinusFrikadelleFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFrikadelleFranskbrød.Text = subAntal(txtAntalFrikadelleFranskbrød.Text);
        }

        private void BtnPlusFlæskestegFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFlæskestegFranskbrød.Text = addAntal(txtAntalFlæskestegFranskbrød.Text);
        }

        private void BtnMinusFlæskestegFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFlæskestegFranskbrød.Text = subAntal(txtAntalFlæskestegFranskbrød.Text);
        }

        private void BtnPlusLeverpostejFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLeverpostejFranskbrød.Text = addAntal(txtAntalLeverpostejFranskbrød.Text);
        }

        private void BtnMinusLeverpostejFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLeverpostejFranskbrød.Text = subAntal(txtAntalLeverpostejFranskbrød.Text);
        }

        private void BtnPlusDyrlægensFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalDyrlægensFranskbrød.Text = addAntal(txtAntalDyrlægensFranskbrød.Text);
        }

        private void BtnMinusDyrlægensFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalDyrlægensFranskbrød.Text = subAntal(txtAntalDyrlægensFranskbrød.Text);
        }

        private void BtnPlusRoastbeefFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRoastbeefFranskbrød.Text = addAntal(txtAntalRoastbeefFranskbrød.Text);
        }

        private void BtnMinusRoastbeefFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRoastbeefFranskbrød.Text = subAntal(txtAntalRoastbeefFranskbrød.Text);
        }

        private void BtnPlusFiskefiletFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFiskefiletFranskbrød.Text = addAntal(txtAntalFiskefiletFranskbrød.Text);
        }

        private void BtnMinusFiskefiletFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFiskefiletFranskbrød.Text = subAntal(txtAntalFiskefiletFranskbrød.Text);
        }

        private void BtnPlusStjernekasterFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStjernekasterFranskbrød.Text = addAntal(txtAntalStjernekasterFranskbrød.Text);
        }

        private void BtnMinusStjernekasterFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStjernekasterFranskbrød.Text = subAntal(txtAntalStjernekasterFranskbrød.Text);
        }

        private void BtnPlusStjerneskudFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStjerneSkudFranskbrød.Text = addAntal(txtAntalStjerneSkudFranskbrød.Text);
        }

        private void BtnMinusStjerneskudFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStjerneSkudFranskbrød.Text = subAntal(txtAntalStjerneSkudFranskbrød.Text);
        }

        private void BtnPlusSkinkeFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSkinkeFranskbrød.Text = addAntal(txtAntalSkinkeFranskbrød.Text);
        }

        private void BtnMinusSkinkeFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSkinkeFranskbrød.Text = subAntal(txtAntalSkinkeFranskbrød.Text);
        }

        private void BtnPlusOksebrystFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalOksebrystFranskbrød.Text = addAntal(txtAntalOksebrystFranskbrød.Text);
        }

        private void BtnMinusOksebrystFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSkinkeFranskbrød.Text = subAntal(txtAntalSkinkeFranskbrød.Text);
        }

        private void BtnPlusKalkunFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKalkunFranskbrød.Text = addAntal(txtAntalKalkunFranskbrød.Text);
        }

        private void BtnMinusKalkunFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKalkunFranskbrød.Text = subAntal(txtAntalKalkunFranskbrød.Text);
        }

        private void BtnPlusTatarFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTatarFranskbrød.Text = addAntal(txtAntalTatarFranskbrød.Text);
        }

        private void BtnMinusTatarFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTatarFranskbrød.Text = subAntal(txtAntalTatarFranskbrød.Text);
        }

        private void BtnPlusMørbradFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMørbradFranskbrød.Text = addAntal(txtAntalMørbradFranskbrød.Text);
        }

        private void BtnMinusMørbradFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMørbradFranskbrød.Text = subAntal(txtAntalMørbradFranskbrød.Text);
        }

        private void BtnPlusBrieFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMinusBrieFranskbrød.Text = addAntal(txtAntalMinusBrieFranskbrød.Text);
        }

        private void BtnMinusBrieFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMinusBrieFranskbrød.Text = subAntal(txtAntalMinusBrieFranskbrød.Text);
        }

        private void BtnPlusMellemlageretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMellemlageretFranskbrød.Text = addAntal(txtAntalMellemlageretFranskbrød.Text);
        }

        private void BtnMinusMellemlageretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalMellemlageretFranskbrød.Text = subAntal(txtAntalMellemlageretFranskbrød.Text);
        }

        private void BtnPlusLageretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLageretFranskbrød.Text = addAntal(txtAntalLageretFranskbrød.Text);
        }

        private void BtnMinusLageretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLageretFranskbrød.Text = subAntal(txtAntalLageretFranskbrød.Text);
        }
        #endregion

        #region checkbox smørrebrød

        private void ChkHåndmadderUspecificeret_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHåndmadderUspecificeret, btnPlusHåndmadderUspecificeretRugbrød, btnMinusHåndmadderUspecificeretRugbrød, txtAntalHåndmadderUspecificeretRugbrød);
            enabledDisabled(chkHåndmadderUspecificeret, btnPlusHåndmadderUspecificeretFranskbrød, btnMinusHåndmadderUspecificeretFranskbrød, txtAntalHåndmadderUspecificeretFranskbrød);
        }
        private void ChkHåndmadderSpecificeret_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHåndmadderSpecificeret, btnPlusHåndmadderSpecificeretRugbrød, btnMinusHåndmadderSpecificeretRugbrød, txtAntalHåndmadderSpecificeretRugbrød);
            enabledDisabled(chkHåndmadderSpecificeret, btnPlusHåndmadderSpecificeretFranskbrød, btnMinusHåndmadderSpecificeretFranskbrød, txtAntalHåndmadderSpecificeretFranskbrød);
        }

        private void ChkHøjtbelagtUspecificeret_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHøjtbelagtUspecificeret, btnPlusHøjtbelagtRugbrød, btnMinusHøjtbelagtRugbrød, txtAntalHøjbelagtRugbrød);
            enabledDisabled(chkHøjtbelagtUspecificeret, btnPlusHøjtbelagtFranskbrød, btnMinusHøjtbelagtFranskbrød, txtAntalHøjtbelagtFranskbrød);
        }

        private void ChkÆgTomat_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkÆgTomat, btnPlusÆgTomatRugbrød, btnMinusÆgTomatRugbrød, txtAntalÆgTomatRugbrød);
            enabledDisabled(chkÆgTomat, btnPlusÆgTomatFranskbrød, btnMinusÆgTomatFranskbrød, txtAntalÆgTomatFranskbrød);
        }

        private void ChkÆgRejer_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkÆgRejer, btnPlusÆgRejerRugbrød, btnMinusÆgRejerRugbrød, txtAntalÆgRejerRugbrød);
            enabledDisabled(chkÆgRejer, btnPlusÆgRejerFranskbrød, btnMinusÆgRejerFranskbrød, txtAntalÆgRejerFranskbrød);
        }

        private void ChkRullepølse_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkRullepølse, btnPlusRullepølseRugbrød, btnMinusRullepølseRugbrød, txtAntalRullepølseRugbrød);
            enabledDisabled(chkRullepølse, btnPlusRullepølseFranskbrød, btnMinusRullepølseFranskbrød, txtAntalRullepølseFranskbrød);
        }

        private void ChkFrikadelle_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkFrikadelle, btnPlusFrikadelleRugbrød, btnMinusFrikadlleRugbrød, txtAntalFrikadelleRugbrød);
            enabledDisabled(chkFrikadelle, btnPlusFrikadelleFranskbrød, btnMinusFrikadelleFranskbrød, txtAntalFrikadelleFranskbrød);
        }

        private void ChkFlæskesteg_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkFlæskesteg, btnPlusFlæskestegRugbrød, btnMinusFlæskestegRugbrød, txtAntalFlæskestegRgbrød);
            enabledDisabled(chkFlæskesteg, btnPlusFlæskestegFranskbrød, btnMinusFlæskestegFranskbrød, txtAntalFlæskestegFranskbrød);
        }

        private void ChkLeverpostej_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkLeverpostej, btnPlusLeverpostejRugbrød, btnMinusLeverpostejRugbrød, txtAntalLeverposteRugbrød);
            enabledDisabled(chkLeverpostej, btnPlusLeverpostejFranskbrød, btnMinusLeverpostejFranskbrød, txtAntalLeverpostejFranskbrød);
        }

        private void ChkDyrelægens_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkDyrelægens, btnPlusDyrlægensRugbrød, btnMinusDyrlægensRugbrød, txtAntalDyrlægensRugbrød);
            enabledDisabled(chkDyrelægens, btnPlusDyrlægensFranskbrød, btnMinusDyrlægensFranskbrød, txtAntalDyrlægensFranskbrød);
        }

        private void ChkRoastbeef_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkRoastbeef, btnPlusRoastbeefRugbrød, btnMinusRoastbeefRugbrød, txtAntalRoastbeefRugbrød);
            enabledDisabled(chkRoastbeef, btnPlusRoastbeefFranskbrød, btnMinusRoastbeefFranskbrød, txtAntalRoastbeefFranskbrød);
        }

        private void ChkFiskefilet_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkFiskefilet, btnPlusFiskefiletRugbrød, btnMinusFiskefiletRugbrød, txtAntalFiskefiletRugbrød);
            enabledDisabled(chkFiskefilet, btnPlusFiskefiletFranskbrød, btnMinusFiskefiletFranskbrød, txtAntalFiskefiletFranskbrød);
        }

        private void ChkStjernekaster_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkStjernekaster, btnPlusStjernekasterRugbrød, btnMinusStjernekasterRugbrød, txtAntalStjernekasterRugbrød);
            enabledDisabled(chkStjernekaster, btnPlusStjernekasterFranskbrød, btnMinusStjernekasterFranskbrød, txtAntalStjernekasterFranskbrød);
        }

        private void ChkStjerneskud_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkStjerneskud, btnPlusStjerneskudRugbrød, btnMinusStjerneskudRugbrød, txtAntalStjerneskudRugbrød);
            enabledDisabled(chkStjerneskud, btnPlusStjerneskudFranskbrød, btnMinusStjerneskudFranskbrød, txtAntalStjerneSkudFranskbrød);
        }

        private void ChkSkinke_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkSkinke, btnPlusSkinkeRugbrød, btnMinusSkinkeRugbrød, txtAntalSkinkeRugbrød);
            enabledDisabled(chkSkinke, btnPlusSkinkeFranskbrød, btnMinusSkinkeFranskbrød, txtAntalSkinkeFranskbrød);
        }

        private void ChkOksebryst_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkOksebryst, btnPlusOksebrystRugbrød, btnMinusOksebrystRugbrød, txtAntalOksebrystRugbrød);
            enabledDisabled(chkOksebryst, btnPlusOksebrystFranskbrød, btnMinusOksebrystFranskbrød, txtAntalOksebrystFranskbrød);
        }

        private void ChkKalkun_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkKalkun, btnPlusKalkunRugbrød, btnMinusKalkunRugbrød, txtAntalKalkunRugbrød);
            enabledDisabled(chkKalkun, btnPlusKalkunFranskbrød, btnMinusKalkunFranskbrød, txtAntalKalkunFranskbrød);
        }

        private void ChkTatar_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkTatar, btnPlusTatarRugbrød, btnMinusTatarRugbrød, txtAntalTatarRugbrød);
            enabledDisabled(chkTatar, btnPlusTatarFranskbrød, btnMinusTatarFranskbrød, txtAntalTatarFranskbrød);
        }

        private void ChkMørbradbøf_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkMørbradbøf, btnPlusMørbradRugbrød, btnMinusMørbradRugbrød, txtAntalMørbradRugbrød);
            enabledDisabled(chkMørbradbøf, btnPlusMørbradFranskbrød, btnMinusMørbradFranskbrød, txtAntalMørbradFranskbrød);
        }

        private void ChkBrie_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkBrie, btnPlusBrieRugbrød, btnMinusBrieRugbrød, txtAntalBrieRugbrød);
            enabledDisabled(chkBrie, btnPlusBrieFranskbrød, btnMinusBrieFranskbrød, txtAntalMinusBrieFranskbrød);
        }

        private void ChkMellemlageret_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkMellemlageret, btnPlusMellemlageretRugbrød, btnMinusMellemlageretRugbrød, txtAntalMellemlageretRugbrød);
            enabledDisabled(chkMellemlageret, btnPlusMellemlageretFranskbrød, btnMinusMellemlageretFranskbrød, txtAntalMellemlageretFranskbrød);
        }

        private void ChkLageret_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkLageret, btnPlusLageretRugbrød, btnMinusLageretRugbrød, txtAntalLageretRugbrød);
            enabledDisabled(chkLageret, btnPlusLageretFranskbrød, btnMinusLageretFranskbrød, txtAntalLageretFranskbrød);
        }
        #endregion

        #region Koldtbord to List

        private void BtnPlusPlatte_Click(object sender, RoutedEventArgs e)
        {
            txtAntalPlatte.Text = addAntal(txtAntalPlatte.Text);
            OrderToList(true, koldtbordPlatte, txtPlatteInfo.Text, Convert.ToDouble(txtPlattePris.Text), Convert.ToInt32(txtAntalPlatte.Text) );
        }

        private void BtnMinusPlatte_Click(object sender, RoutedEventArgs e)
        {
            txtAntalPlatte.Text = subAntal(txtAntalPlatte.Text);
            OrderToList(false, koldtbordPlatte, txtPlatteInfo.Text, Convert.ToDouble(txtPlattePris.Text), Convert.ToInt32(txtAntalPlatte.Text) );
        }

        private void BtnPlusKoldtbord_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKoldtbord.Text = addAntal(txtAntalKoldtbord.Text);
            OrderToList(true, koldtbord, txtKoldtbordInfo.Text, Convert.ToDouble(txtKoldtbordPris.Text), Convert.ToInt32(txtAntalKoldtbord.Text) );
        }

        private void BtnMinusKoldtbord_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKoldtbord.Text = subAntal(txtAntalKoldtbord.Text);
            OrderToList(false, koldtbord, txtKoldtbordInfo.Text, Convert.ToDouble(txtKoldtbordPris.Text), Convert.ToInt32(txtAntalKoldtbord.Text) );
        }

        private void BtnPlusLuksusplatte_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLuksusplatte.Text = addAntal(txtAntalLuksusplatte.Text);
            OrderToList(true, koldtbordLuksusPlatte, txtLuksusPlatteInfo.Text, Convert.ToDouble(txtLuksusPlattePris.Text), Convert.ToInt32(txtAntalLuksusplatte.Text) );
        }

        private void BtnMinusLuksusplatte_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLuksusplatte.Text = subAntal(txtAntalLuksusplatte.Text);
            OrderToList(true, koldtbordLuksusPlatte, txtLuksusPlatteInfo.Text, Convert.ToDouble(txtLuksusPlattePris.Text), Convert.ToInt32(txtAntalLuksusplatte.Text) );
        }

        private void ChkKoldtbord_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkKoldtbord, btnPlusKoldtbord, btnMinusKoldtbord, txtAntalKoldtbord);
        }

        private void ChkPlatte_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkPlatte, btnPlusPlatte, btnMinusPlatte, txtAntalPlatte);
        }

        private void ChkLuksusplatte_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkLuksusplatte, btnPlusLuksusplatte, btnMinusLuksusplatte, txtAntalLuksusplatte);
        }
        #endregion

        #region Checkbox metoder af kartofler i "Buffet"

        private void ChkFlødekartofler_Click(object sender, RoutedEventArgs e)
        {
           CheckPotato();
        }

        private void ChkBagtKartoffel_Click(object sender, RoutedEventArgs e)
        {
           CheckPotato(); 
        }

        private void ChkKartoffelsalat_Click(object sender, RoutedEventArgs e)
        {

            CheckPotato();
        }

        private void ChkTimianKartofler_Click(object sender, RoutedEventArgs e)
        {

            CheckPotato();
        }

        private void ChkSmørstegteKartofler_Click(object sender, RoutedEventArgs e)
        {
           CheckPotato();
        }

        private void ChkKogteKartofler_Click(object sender, RoutedEventArgs e)
        {
            CheckPotato();
        }

        #endregion

        #region Checkbox metoder af sauce i "Buffet"
        private void ChkBearnaise_Click(object sender, RoutedEventArgs e)
        {
            CheckSauce();
        }

        private void ChkRødvindssauce_Click(object sender, RoutedEventArgs e)
        {
            CheckSauce();
        }

        private void ChkSkysauce_Click(object sender, RoutedEventArgs e)
        {
            CheckSauce();
        }

        private void ChkHollandaise_Click(object sender, RoutedEventArgs e)
        {
            CheckSauce();
        }

        private void ChkDressing_Click(object sender, RoutedEventArgs e)
        {
            CheckSauce();

        }

        #endregion

        #region Checkbox metoder Kød i "Buffet"

        private void ChkHvidvinsLaks_Click(object sender, RoutedEventArgs e)
        {
            CheckMeet();
        }

        private void ChkOksefilet_Click(object sender, RoutedEventArgs e)
        {
            CheckMeet();
        }

        private void ChkGlaseretSkinke_Click(object sender, RoutedEventArgs e)
        {
            CheckMeet();
        }

        private void ChkSvinekam_Click(object sender, RoutedEventArgs e)
        {
            CheckMeet();
        }

        private void ChkKyllingefilet_Click(object sender, RoutedEventArgs e)
        {
            CheckMeet();
        }

        private void ChkLammekølle_Click(object sender, RoutedEventArgs e)
        {
            CheckMeet();
        }

        private void ChkFrikadeller_Click(object sender, RoutedEventArgs e)
        {
            CheckMeet();
        }

        private void ChkKalveculotte_Click(object sender, RoutedEventArgs e)
        {
            CheckMeet();
        }

        private void ChkAndebryst_Click(object sender, RoutedEventArgs e)
        {
            CheckMeet();
        }

        #endregion

        #region Checkbox metoder Salat i "Buffet"

        private void ChkGrønsalatBuffet_Click(object sender, RoutedEventArgs e)
        {
            CheckSalad();
        }

        private void ChkPastasalatBuffet_Click(object sender, RoutedEventArgs e)
        {
            CheckSalad();
        }

        private void ChkTomatsalatBuffet_Click(object sender, RoutedEventArgs e)
        {
            CheckSalad();
        }

        private void ChkBroccolisalatBuffet_Click(object sender, RoutedEventArgs e)
        {
            CheckSalad();
        }

        private void ChkRodfrugterBuffet_Click(object sender, RoutedEventArgs e)
        {
            CheckSalad();
        }

        private void ChkBulgursalatBuffet_Click(object sender, RoutedEventArgs e)
        {
            CheckSalad();
        }
        #endregion

        #region BuffetToList

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKuverter.Text = addAntal(txtAntalKuverter.Text);

        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKuverter.Text = subAntal(txtAntalKuverter.Text);
        }

        #endregion

        #region ForretToList
        private void BtnPlusHvidvinslaks_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHvidvinslaks.Text = addAntal(txtAntalHvidvinslaks.Text);
            OrderToList(true, forretHvidvinslaks, txtForretHvidvinsLaks.Text ,Convert.ToDouble(txtForretHvidvinsLaksPris.Text), Convert.ToInt32(txtAntalHvidvinslaks.Text));
        }
    
        private void BtnMinusHvidvinslaks_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHvidvinslaks.Text = subAntal(txtAntalHvidvinslaks.Text);
            OrderToList(false, forretHvidvinslaks, txtForretHvidvinsLaks.Text, Convert.ToDouble(txtForretHvidvinsLaksPris.Text), Convert.ToInt32(txtAntalHvidvinslaks.Text));
        }

        private void BtnPlusVarmrøgetLaks_Click(object sender, RoutedEventArgs e)
        {
            txtAntalVarmrøgetLaks.Text = addAntal(txtAntalVarmrøgetLaks.Text);
            OrderToList(true, forretVarmrøgetlaks, txtForretVarmrøgetLaks.Text, Convert.ToDouble(txtForretVarmrøgetLaksPris.Text), Convert.ToInt32(txtAntalVarmrøgetLaks.Text));
        }

        private void BtnMinusVarmrøgetLaks_Click(object sender, RoutedEventArgs e)
        {
            txtAntalVarmrøgetLaks.Text = subAntal(txtAntalVarmrøgetLaks.Text);
            OrderToList(false, forretVarmrøgetlaks, txtForretVarmrøgetLaks.Text, Convert.ToDouble(txtForretVarmrøgetLaksPris.Text), Convert.ToInt32(txtAntalVarmrøgetLaks.Text));
        }

        private void BtnPlusCapaccio_Click(object sender, RoutedEventArgs e)
        {
            txtAntalCapaccio.Text = addAntal(txtAntalCapaccio.Text);
            OrderToList(true, forretCapaccio, txtForretCapaccio.Text, Convert.ToDouble(txtForretCapaccionPris.Text), Convert.ToInt32(txtAntalCapaccio.Text));
        }

        private void BtnMinusCapaccio_Click(object sender, RoutedEventArgs e)
        {
            txtAntalCapaccio.Text = subAntal(txtAntalCapaccio.Text);
            OrderToList(false, forretCapaccio, txtForretCapaccio.Text, Convert.ToDouble(txtForretCapaccionPris.Text), Convert.ToInt32(txtAntalCapaccio.Text));
        }

        private void BtnPlusLakseroulade_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLakseroulade.Text = addAntal(txtAntalLakseroulade.Text);
            OrderToList(true, forretLakseroulade, txtForretLakseroulade.Text, Convert.ToDouble(txtForretLakserouladePris.Text), Convert.ToInt32(txtAntalLakseroulade.Text));
        }

        private void BtnMinusLakseroulade_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLakseroulade.Text = subAntal(txtAntalLakseroulade.Text);
            OrderToList(false, forretLakseroulade, txtForretLakseroulade.Text, Convert.ToDouble(txtForretLakserouladePris.Text), Convert.ToInt32(txtAntalLakseroulade.Text));
        }

        private void BtnPlusTunmousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTunmousse.Text = addAntal(txtAntalTunmousse.Text);
            OrderToList(true, forretTunmousse, txtForretTunmousse.Text, Convert.ToDouble(txtForretTunmoussePris.Text), Convert.ToInt32(txtAntalTunmousse.Text));
        }

        private void BtnMinusTunmousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTunmousse.Text = subAntal(txtAntalTunmousse.Text);
            OrderToList(false, forretTunmousse, txtForretTunmousse.Text, Convert.ToDouble(txtForretTunmoussePris.Text), Convert.ToInt32(txtAntalTunmousse.Text));
        }

        private void BtnPlusSeranoskinke_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSeranoskinke.Text = addAntal(txtAntalSeranoskinke.Text);
            OrderToList(true, forretSeranoskine, txtForretSeranoskinke.Text, Convert.ToDouble(txtForretSeranoskinkePris.Text), Convert.ToInt32(txtAntalSeranoskinke.Text));
        }

        private void BtnMinusSeranoskinke_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSeranoskinke.Text = subAntal(txtAntalSeranoskinke.Text);
            OrderToList(false, forretSeranoskine, txtForretSeranoskinke.Text, Convert.ToDouble(txtForretSeranoskinkePris.Text), Convert.ToInt32(txtAntalSeranoskinke.Text));
        }

        private void BtnPlusLaksemousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLaksemousse.Text = addAntal(txtAntalLaksemousse.Text);
            OrderToList(true, forretLaksemousse, txtForretLaksemousse.Text, Convert.ToDouble(txtForretLaksemoussePris.Text), Convert.ToInt32(txtAntalLaksemousse.Text));
        }

        private void BtnMinusLaksemousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLaksemousse.Text = subAntal(txtAntalLaksemousse.Text);
            OrderToList(false, forretLaksemousse, txtForretLaksemousse.Text, Convert.ToDouble(txtForretLaksemoussePris.Text), Convert.ToInt32(txtAntalLaksemousse.Text));
        }

        private void enabledDisabled(CheckBox chkFood, Button btnAdd, Button btnSub, TextBlock txtBlock)
        {
            if (chkFood.IsChecked == true)
            {
                btnAdd.IsEnabled = true;

                btnSub.IsEnabled = true;
            }
            else
            {
                btnAdd.IsEnabled = false;
                btnSub.IsEnabled = false;
                txtBlock.Text = "0";
            }
        }

        private void ChkVarmrøgetLaks_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkVarmrøgetLaks, btnPlusVarmrøgetLaks, btnMinusVarmrøgetLaks, txtAntalVarmrøgetLaks);
        }

        private void ChkHvidvinslaks_Click_1(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHvidvinslaks, btnPlusHvidvinslaks, btnMinusHvidvinslaks, txtAntalHvidvinslaks);
        }

        private void ChkCarpaccio_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkCarpaccio, btnPlusCapaccio, btnMinusCapaccio, txtAntalCapaccio);
        }

        private void ChkLakseroulade_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkLakseroulade, btnPlusLakseroulade, btnMinusLakseroulade, txtAntalLakseroulade);
        }

        private void ChkTunmousse_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkTunmousse, btnPlusTunmousse, btnMinusTunmousse, txtAntalTunmousse);
        }

        private void ChkSeranoskinke_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkSeranoskinke, btnPlusSeranoskinke, btnMinusSeranoskinke, txtAntalSeranoskinke);
        }

        private void ChkLaksemousse_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkLaksemousse, btnPlusLaksemousse, btnMinusLaksemousse, txtAntalLaksemousse);
        }
        #endregion

        #region HovedretToList

        private void BtnPlusKalveculotte_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKalveculotte.Text = addAntal(txtAntalKalveculotte.Text);
            OrderToList(true, hovedretKalveculotte, txtHovedretKalveculotte.Text, Convert.ToDouble(txtHovedretKalveculottePris.Text), Convert.ToInt32(txtAntalKalveculotte.Text));
        }

        private void BtnMinusKalveculotte_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKalveculotte.Text = subAntal(txtAntalKalveculotte.Text);
            OrderToList(false, hovedretKalveculotte, txtHovedretKalveculotte.Text, Convert.ToDouble(txtHovedretKalveculottePris.Text), Convert.ToInt32(txtAntalKalveculotte.Text));
        }

        private void BtnPlusOksefilet_Click(object sender, RoutedEventArgs e)
        {
            txtAntalOksefilet.Text = addAntal(txtAntalOksefilet.Text);
            OrderToList(true, hovedretOksefilet, txtHovedretOksefilet.Text, Convert.ToDouble(txtHovedretOksefiletPris.Text), Convert.ToInt32(txtAntalOksefilet.Text));
        }

        private void BtnMinusOksefilet_Click(object sender, RoutedEventArgs e)
        {
            txtAntalOksefilet.Text = subAntal(txtAntalOksefilet.Text);
            OrderToList(false, hovedretOksefilet, txtHovedretOksefilet.Text, Convert.ToDouble(txtHovedretOksefiletPris.Text), Convert.ToInt32(txtAntalOksefilet.Text));
        }

        private void BtnPlusFlæskesteg_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFlæskesteg.Text = addAntal(txtAntalFlæskesteg.Text);
            OrderToList(true, hovedretFlæskesteg, txtHovedretFlæskesteg.Text, Convert.ToDouble(txtHovedretFlæskestegPris.Text), Convert.ToInt32(txtAntalFlæskesteg.Text));
        }

        private void BtnMinusFlæskesteg_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFlæskesteg.Text = subAntal(txtAntalFlæskesteg.Text);
            OrderToList(false, hovedretFlæskesteg, txtHovedretFlæskesteg.Text, Convert.ToDouble(txtHovedretFlæskestegPris.Text), Convert.ToInt32(txtAntalFlæskesteg.Text));
        }

        private void BtnPlusKyllingefilet_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKyllingefilet.Text = addAntal(txtAntalKyllingefilet.Text);
            OrderToList(true, hovedretKylligefilet, txtHovedretKyllingefilet.Text, Convert.ToDouble(txtHovedretKyllingefiletPris.Text), Convert.ToInt32(txtAntalKyllingefilet.Text));
        }

        private void BtnMinusKyllingefilet_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKyllingefilet.Text = subAntal(txtAntalKyllingefilet.Text);
            OrderToList(false, hovedretKylligefilet, txtHovedretKyllingefilet.Text, Convert.ToDouble(txtHovedretKyllingefiletPris.Text), Convert.ToInt32(txtAntalKyllingefilet.Text));
        }

        private void BtnPlusGlaseretSkinke_Click(object sender, RoutedEventArgs e)
        {
            txtAntalGlaseretSkinke.Text = addAntal(txtAntalGlaseretSkinke.Text);
            OrderToList(true, hovedretGlaseretSkinke, txtHovedretGlaseretSkinke.Text, Convert.ToDouble(txtHovedretGlaseretSkinkePris.Text), Convert.ToInt32(txtAntalGlaseretSkinke.Text));
        }

        private void BtnMinusGlaseretSkinke_Click(object sender, RoutedEventArgs e)
        {
            txtAntalGlaseretSkinke.Text = subAntal(txtAntalGlaseretSkinke.Text);
            OrderToList(false, hovedretGlaseretSkinke, txtHovedretGlaseretSkinke.Text, Convert.ToDouble(txtHovedretGlaseretSkinkePris.Text), Convert.ToInt32(txtAntalGlaseretSkinke.Text));
        }

        private void BtnPlusLaksesteak_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLaksesteak.Text = addAntal(txtAntalLaksesteak.Text);
            OrderToList(true, hovedretLaksesteak, txtHovedretLaksesteak.Text, Convert.ToDouble(txtHovedretLaksesteakPris.Text), Convert.ToInt32(txtAntalLaksesteak.Text));
        }

        private void BtnMinusLaksesteak_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLaksesteak.Text = subAntal(txtAntalLaksesteak.Text);
            OrderToList(false, hovedretLaksesteak, txtHovedretLaksesteak.Text, Convert.ToDouble(txtHovedretLaksesteakPris.Text), Convert.ToInt32(txtAntalLaksesteak.Text));
        }

        private void BtnPlusKalvesteg_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKalvesteg.Text = addAntal(txtAntalKalvesteg.Text);
            OrderToList(true, hovedretKalvesteg, txtHovedretKalvesteg.Text, Convert.ToDouble(txtHovedretKalvestegPris.Text), Convert.ToInt32(txtAntalKalvesteg.Text));
        }

        private void BtnMinusKalvesteg_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKalvesteg.Text = subAntal(txtAntalKalvesteg.Text);
            OrderToList(false, hovedretKalvesteg, txtHovedretKalvesteg.Text, Convert.ToDouble(txtHovedretKalvestegPris.Text), Convert.ToInt32(txtAntalKalvesteg.Text));
        }

        private void BtnPlusLammekølle_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLammekølle.Text = addAntal(txtAntalLammekølle.Text);
            OrderToList(true, hovedretLammekølle, txtHovedretLammekølle.Text, Convert.ToDouble(txtHovedretLammekøllePris.Text), Convert.ToInt32(txtAntalLammekølle.Text));
        }

        private void BtnMinusLammekølle_Click(object sender, RoutedEventArgs e)
        {
            txtAntalLammekølle.Text = subAntal(txtAntalLammekølle.Text);
            OrderToList(false, hovedretLammekølle, txtHovedretLammekølle.Text, Convert.ToDouble(txtHovedretLammekøllePris.Text), Convert.ToInt32(txtAntalLammekølle.Text));
        }

        private void ChkHovedretKalveculotte_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHovedretKalveculotte, btnPlusKalveculotte, btnMinusKalveculotte, txtAntalKalveculotte);
        }

        private void ChkHovedretOksefilet_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHovedretOksefilet, btnPlusOksefilet, btnMinusOksefilet, txtAntalOksefilet);
        }

        private void ChkHovedretFlæskesteg_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHovedretFlæskesteg, btnPlusFlæskesteg, btnMinusFlæskesteg, txtAntalFlæskesteg);
        }

        private void ChkHovedretKyllingefilet_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHovedretKyllingefilet, btnPlusKyllingefilet, btnMinusKyllingefilet, txtAntalKyllingefilet);
        }

        private void ChkHovedretGlaseretSkinke_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHovedretGlaseretSkinke, btnPlusGlaseretSkinke, btnMinusGlaseretSkinke, txtAntalGlaseretSkinke);
        }

        private void ChkHovedretLaksesteak_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHovedretLaksesteak, btnPlusLaksesteak, btnMinusLaksesteak, txtAntalLaksesteak);
        }

        private void ChkHovedretKalvesteg_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHovedretKalvesteg, btnPlusKalvesteg, btnMinusKalvesteg, txtAntalKalvesteg);
        }

        private void ChkHovedretLammekølle_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkHovedretLammekølle, btnPlusLammekølle, btnMinusLammekølle, txtAntalLammekølle);
        }

        #endregion

        #region DessertToList

        private void BtnPlusÆblekage_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆblekage.Text = addAntal(txtAntalÆblekage.Text);
            OrderToList(true, dessertÆblekage, txtDessertÆblekage.Text, Convert.ToDouble(txtDessertÆblekagePris.Text),Convert.ToInt32(txtAntalÆblekage.Text));
            
        }
        
        private void BtnMinusÆblekage_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆblekage.Text = subAntal(txtAntalÆblekage.Text);
            OrderToList(false, dessertÆblekage, txtDessertÆblekage.Text, Convert.ToDouble(txtDessertÆblekagePris.Text),Convert.ToInt32(txtAntalÆblekage.Text));
        }

        private void BtnPlusChokolademousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalChokolademousse.Text = addAntal(txtAntalChokolademousse.Text);
            OrderToList(true, dessertChokolademousse, txtDessertChokolademousse.Text, Convert.ToDouble(txtDessertChokolademoussePris.Text),Convert.ToInt32(txtAntalChokolademousse.Text));

        }

        private void BtnMinusChokolademousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalChokolademousse.Text = subAntal(txtAntalChokolademousse.Text);
            OrderToList(false, dessertChokolademousse, txtDessertChokolademousse.Text, Convert.ToDouble(txtDessertChokolademoussePris.Text),Convert.ToInt32(txtAntalChokolademousse.Text));

        }

        private void BtnPlusPassionsmousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalPassionsmousse.Text = addAntal(txtAntalPassionsmousse.Text);
            OrderToList(true, dessertPassionsmousse, txtDessertPassionsmousse.Text, Convert.ToDouble(txtDessertPassionsmoussePris.Text),Convert.ToInt32(txtAntalPassionsmousse.Text));

        }

        private void BtnMinusPassionsmousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalPassionsmousse.Text = subAntal(txtAntalPassionsmousse.Text);
            OrderToList(false, dessertPassionsmousse, txtDessertPassionsmousse.Text, Convert.ToDouble(txtDessertPassionsmoussePris.Text),Convert.ToInt32(txtAntalPassionsmousse.Text));

        }

        private void BtnPlusSkovbærtærte_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSkovbærtærte.Text = addAntal(txtAntalSkovbærtærte.Text);
            OrderToList(true, dessertSkovbærtærte, txtDessertSkovbærtærte.Text, Convert.ToDouble(txtDessertSkovbærtærtePris.Text),Convert.ToInt32(txtAntalSkovbærtærte.Text));
        }

        private void BtnMinusSkovbærtærte_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSkovbærtærte.Text = subAntal(txtAntalSkovbærtærte.Text);
            OrderToList(false, dessertSkovbærtærte, txtDessertSkovbærtærte.Text, Convert.ToDouble(txtDessertSkovbærtærtePris.Text),Convert.ToInt32(txtAntalSkovbærtærte.Text));
        }

        private void BtnPlusFriskFrugt_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFriskFrugt.Text = addAntal(txtAntalFriskFrugt.Text);
            OrderToList(true, dessertFriskFrugt, txtDessertFriskFrugt.Text, Convert.ToDouble(txtDessertFriskFrugtPris.Text),Convert.ToInt32(txtAntalFriskFrugt.Text));
        }

        private void BtnMinusFriskFrugt_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFriskFrugt.Text = subAntal(txtAntalFriskFrugt.Text);
            OrderToList(false, dessertFriskFrugt, txtDessertFriskFrugt.Text, Convert.ToDouble(txtDessertFriskFrugtPris.Text),Convert.ToInt32(txtAntalFriskFrugt.Text));
        }

        private void BtnPlusHindbærmousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHindbærmousse.Text = addAntal(txtAntalHindbærmousse.Text);
            OrderToList(true, dessertHindbærmousse, txtDessertHindbærmousse.Text, Convert.ToDouble(txtDessertHindbærmoussePris.Text),Convert.ToInt32(txtAntalHindbærmousse.Text));
        }

        private void BtnMinusHindbærmousse_Click(object sender, RoutedEventArgs e)
        {
            txtAntalHindbærmousse.Text = subAntal(txtAntalHindbærmousse.Text);
            OrderToList(false, dessertHindbærmousse, txtDessertHindbærmousse.Text, Convert.ToDouble(txtDessertHindbærmoussePris.Text),Convert.ToInt32(txtAntalHindbærmousse.Text));
        }

        private void BtnPlusChokoladekage_Click(object sender, RoutedEventArgs e)
        {
            txtAntalChokoladekage.Text = addAntal(txtAntalChokoladekage.Text);
            OrderToList(true, dessertChokoladekage, txtDessertChokoladekage.Text, Convert.ToDouble(txtDessertChokoladekagePris.Text),Convert.ToInt32(txtAntalChokoladekage.Text));
        }

        private void BtnMinusChokoladekage_Click(object sender, RoutedEventArgs e)
        {
            txtAntalChokoladekage.Text = subAntal(txtAntalChokoladekage.Text);
            OrderToList(false, dessertChokoladekage, txtDessertChokoladekage.Text, Convert.ToDouble(txtDessertChokoladekagePris.Text),Convert.ToInt32(txtAntalChokoladekage.Text));
        }

        private void BtnPlusBlåbærCheesecake_Click(object sender, RoutedEventArgs e)
        {
            txtAntalBlåbærCheesecake.Text = addAntal(txtAntalBlåbærCheesecake.Text);
            OrderToList(true, dessertBlåbærCheesecake, txtDessertBlåbærCheesecake.Text, Convert.ToDouble(txtDessertBlåbærCheesecakePris.Text),Convert.ToInt32(txtAntalBlåbærCheesecake.Text));
        }

        private void BtnMinusBlåbærCheesecake_Click(object sender, RoutedEventArgs e)
        {
            txtAntalBlåbærCheesecake.Text = subAntal(txtAntalBlåbærCheesecake.Text);
            OrderToList(false, dessertBlåbærCheesecake, txtDessertBlåbærCheesecake.Text, Convert.ToDouble(txtDessertBlåbærCheesecakePris.Text),Convert.ToInt32(txtAntalBlåbærCheesecake.Text));
        }

        private void ChkDessertÆblekage_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkDessertÆblekage, btnPlusÆblekage, btnMinusÆblekage, txtAntalÆblekage);
        }

        private void ChkDessertChokolademousse_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkDessertChokolademousse, btnPlusChokolademousse, btnMinusChokolademousse, txtAntalChokolademousse);
        }

        private void ChkDessertPassionsmousse_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkDessertPassionsmousse, btnPlusPassionsmousse, btnMinusPassionsmousse, txtAntalPassionsmousse);
        }

        private void ChkDessertSkovbærstærte_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkDessertSkovbærstærte, btnPlusSkovbærtærte, btnMinusSkovbærtærte, txtAntalSkovbærtærte);
        }

        private void ChkDessertFriskFrugt_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkDessertFriskFrugt, btnPlusFriskFrugt, btnMinusFriskFrugt, txtAntalFriskFrugt);
        }

        private void ChkDessertHindbærmousse_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkDessertHindbærmousse, btnPlusHindbærmousse, btnMinusHindbærmousse, txtAntalHindbærmousse);
        }

        private void ChkDessertChokoladekage_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkDessertChokoladekage, btnPlusChokoladekage, btnMinusChokoladekage, txtAntalChokoladekage);
        }

        private void ChkDessertBlåbærCheesecake_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkDessertBlåbærCheesecake, btnPlusBlåbærCheesecake, btnMinusBlåbærCheesecake, txtAntalBlåbærCheesecake);
        }

        #endregion

        #region SaladToList

       private void BtnPlusBroccolisalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalBroccolisalat.Text = addAntal(txtAntalBroccolisalat.Text);
            OrderToList(true, salatBroccolisalat, txtBroccolisalatNavn.Text, Convert.ToDouble(txtBroccolisalatPris.Text), Convert.ToInt32(txtAntalBroccolisalat.Text));
        }

        private void BtnMinusBroccolisalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalBroccolisalat.Text = subAntal(txtAntalBroccolisalat.Text);
            OrderToList(false, salatBroccolisalat, txtBroccolisalatNavn.Text, Convert.ToDouble(txtBroccolisalatPris.Text), Convert.ToInt32(txtAntalBroccolisalat.Text));
        }

        private void BtnPlusGrønsalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalGrønsalat.Text = addAntal(txtAntalGrønsalat.Text);
            OrderToList(true, salatGrønsalat, txtGrønsalatNavn.Text, Convert.ToDouble(txtGrønsalatPris.Text), Convert.ToInt32(txtAntalGrønsalat.Text));
        }

        private void BtnMinusGrønsalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalGrønsalat.Text = subAntal(txtAntalGrønsalat.Text);
            OrderToList(false, salatGrønsalat, txtGrønsalatNavn.Text, Convert.ToDouble(txtGrønsalatPris.Text), Convert.ToInt32(txtAntalGrønsalat.Text));
        }

        private void BtnPlusTomatsalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTomatsalat.Text = addAntal(txtAntalTomatsalat.Text);
            OrderToList(true, salatTomatsalat, txtTomatsalatNavn.Text, Convert.ToDouble(txtTomatsalatPris.Text), Convert.ToInt32(txtAntalTomatsalat.Text));
        }

        private void BtnMinusTomatsalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTomatsalat.Text = subAntal(txtAntalTomatsalat.Text);
            OrderToList(false, salatTomatsalat, txtTomatsalatNavn.Text, Convert.ToDouble(txtTomatsalatPris.Text), Convert.ToInt32(txtAntalTomatsalat.Text));
        }

        private void BtnPlusPastasalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalPastasalat.Text = addAntal(txtAntalPastasalat.Text);
            OrderToList(true, salatPastasalat, txtPastasalatNavn.Text, Convert.ToDouble(txtPastasalatPris.Text), Convert.ToInt32(txtAntalPastasalat.Text));
        }

        private void BtnMinusPastasalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalPastasalat.Text = subAntal(txtAntalPastasalat.Text);
            OrderToList(false, salatPastasalat, txtPastasalatNavn.Text, Convert.ToDouble(txtPastasalatPris.Text), Convert.ToInt32(txtAntalPastasalat.Text));
        }

        private void ChkBroccolisalat_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkBroccolisalat, btnPlusBroccolisalat, btnMinusBroccolisalat, txtAntalBroccolisalat);
        }

        private void ChkGrønssalat_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkGrønssalat, btnPlusGrønsalat, btnMinusGrønsalat, txtAntalGrønsalat);
        }

        private void ChkTomatsalat_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkTomatsalat, btnPlusTomatsalat, btnMinusTomatsalat, txtAntalTomatsalat);
        }

        private void ChkPastasalat_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkPastasalat, btnPlusPastasalat, btnMinusPastasalat, txtAntalPastasalat);
        }




        #endregion

        #region SandwichToList

        private void BtnPlusKyllingSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKyllingSandwich.Text = addAntal(txtAntalKyllingSandwich.Text);
            OrderToList(true, sandwichKylling, txtKyllingSandwichNavn.Text, Convert.ToDouble(txtKyllingSandwichPris.Text), Convert.ToInt32(txtAntalKyllingSandwich.Text));
        }

        private void BtnMinusKyllingSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalKyllingSandwich.Text = subAntal(txtAntalKyllingSandwich.Text);
            OrderToList(false, sandwichKylling, txtKyllingSandwichNavn.Text, Convert.ToDouble(txtKyllingSandwichPris.Text), Convert.ToInt32(txtAntalKyllingSandwich.Text));
        }

        private void BtnPlusÆgBacon_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆgBacon.Text = addAntal(txtAntalÆgBacon.Text);
            OrderToList(true, sandwichÆgBacon, txtÆgBaconSandwichNavn.Text, Convert.ToDouble(txtÆgBaconSandwichPris.Text), Convert.ToInt32(txtAntalÆgBacon.Text));
        }

        private void BtnMinusÆgBacon_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆgBacon.Text = subAntal(txtAntalÆgBacon.Text);
            OrderToList(false, sandwichÆgBacon, txtÆgBaconSandwichNavn.Text, Convert.ToDouble(txtÆgBaconSandwichPris.Text), Convert.ToInt32(txtAntalÆgBacon.Text));
        }

        private void BtnPlusRoastbeefSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRoastbeefSandwich.Text = addAntal(txtAntalRoastbeefSandwich.Text);
            OrderToList(true, sandwichRoastbeef, txtRoastbeefSandwichNavn.Text, Convert.ToDouble(txtRoastbeefSandwichPris.Text), Convert.ToInt32(txtAntalRoastbeefSandwich.Text));
        }

        private void BtnMinusRoastbeefSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRoastbeefSandwich.Text = subAntal(txtAntalRoastbeefSandwich.Text);
            OrderToList(false, sandwichRoastbeef, txtRoastbeefSandwichNavn.Text, Convert.ToDouble(txtRoastbeefSandwichPris.Text), Convert.ToInt32(txtAntalRoastbeefSandwich.Text));
        }

        private void BtnPlusStegSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStegSandwich.Text = addAntal(txtAntalStegSandwich.Text);
            OrderToList(true, sandwichSteg, txtStegSandwichNavn.Text, Convert.ToDouble(txtstegSandwichPris.Text), Convert.ToInt32(txtAntalStegSandwich.Text));
        }

        private void BtnMinusStegSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalStegSandwich.Text = subAntal(txtAntalStegSandwich.Text);
            OrderToList(false, sandwichSteg, txtStegSandwichNavn.Text, Convert.ToDouble(txtstegSandwichPris.Text), Convert.ToInt32(txtAntalStegSandwich.Text));
        }

        private void BtnPlusFrikadelleSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFrikadelleSandwich.Text = addAntal(txtAntalFrikadelleSandwich.Text);
            OrderToList(true, sandwichFrikadelle, txtFrikadeleSandwichNavn.Text, Convert.ToDouble(txtFrikadelleSandwichPris.Text), Convert.ToInt32(txtAntalFrikadelleSandwich.Text));
        }

        private void BtnMinusFrikadelleSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalFrikadelleSandwich.Text = subAntal(txtAntalFrikadelleSandwich.Text);
            OrderToList(false, sandwichFrikadelle, txtFrikadeleSandwichNavn.Text, Convert.ToDouble(txtFrikadelleSandwichPris.Text), Convert.ToInt32(txtAntalFrikadelleSandwich.Text));
        }

        private void BtnPlusSkinkeOst_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSkinkeOst.Text = addAntal(txtAntalSkinkeOst.Text);
            OrderToList(true, sandwichSkinkeOst, txtSkinkeOstSandwichNavn.Text, Convert.ToDouble(txtSkinkeOstSandwichPris.Text), Convert.ToInt32(txtAntalSkinkeOst.Text));
        }

        private void BtnMinusSkinkeOst_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSkinkeOst.Text = subAntal(txtAntalSkinkeOst.Text);
            OrderToList(false, sandwichSkinkeOst, txtSkinkeOstSandwichNavn.Text, Convert.ToDouble(txtSkinkeOstSandwichPris.Text), Convert.ToInt32(txtAntalSkinkeOst.Text));
        }

        private void BtnPlusRøgetLaksSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRøgetLaksSandwich.Text = addAntal(txtAntalRøgetLaksSandwich.Text);
            OrderToList(true, sandwichRøgetLaks, txtRøgetLaksNavn.Text, Convert.ToDouble(txtRøgetLaksSandwichPris.Text), Convert.ToInt32(txtAntalRøgetLaksSandwich.Text));
        }

        private void BtnMinusRøgetLaksSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalRøgetLaksSandwich.Text = subAntal(txtAntalRøgetLaksSandwich.Text);
            OrderToList(false, sandwichRøgetLaks, txtRøgetLaksNavn.Text, Convert.ToDouble(txtRøgetLaksSandwichPris.Text), Convert.ToInt32(txtAntalRøgetLaksSandwich.Text));
        }

        private void BtnPlusÆgRejerSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆgRejerSandwich.Text = addAntal(txtAntalÆgRejerSandwich.Text);
            OrderToList(true, sandwichÆgRejer, txtÆgRejerSandwichNavn.Text, Convert.ToDouble(txtÆgRejerSandwichPris.Text), Convert.ToInt32(txtAntalÆgRejerSandwich.Text));
        }

        private void BtnMinusÆgRejerSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆgRejerSandwich.Text = subAntal(txtAntalÆgRejerSandwich.Text);
            OrderToList(false, sandwichÆgRejer, txtÆgRejerSandwichNavn.Text, Convert.ToDouble(txtÆgRejerSandwichPris.Text), Convert.ToInt32(txtAntalÆgRejerSandwich.Text));
        }

        private void BtnPlusTunsalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTunsalat.Text = addAntal(txtAntalTunsalat.Text);
            OrderToList(true, sandwichTunsalat, txtTunsalatSandwichNavn.Text, Convert.ToDouble(txtTunsalatSandwichPris.Text), Convert.ToInt32(txtAntalTunsalat.Text));
        }

        private void BtnMinusTunsalat_Click(object sender, RoutedEventArgs e)
        {
            txtAntalTunsalat.Text = subAntal(txtAntalTunsalat.Text);
            OrderToList(false, sandwichTunsalat, txtTunsalatSandwichNavn.Text, Convert.ToDouble(txtTunsalatSandwichPris.Text), Convert.ToInt32(txtAntalTunsalat.Text));
        }

        private void BtnPlusSeranoSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSeranoSandwich.Text = addAntal(txtAntalSeranoSandwich.Text);
            OrderToList(true, sandwichSerano, txtSeranoSandwichNavn.Text, Convert.ToDouble(txtSeranoSandwichPris.Text), Convert.ToInt32(txtAntalSeranoSandwich.Text));
        }

        private void BtnMinusSeranoSandwich_Click(object sender, RoutedEventArgs e)
        {
            txtAntalSeranoSandwich.Text = subAntal(txtAntalSeranoSandwich.Text);
            OrderToList(false, sandwichSerano, txtSeranoSandwichNavn.Text, Convert.ToDouble(txtSeranoSandwichPris.Text), Convert.ToInt32(txtAntalSeranoSandwich.Text));
        }

        private void ChkKyllingSandwich_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkKyllingSandwich, btnPlusKyllingSandwich, btnMinusKyllingSandwich, txtAntalKyllingSandwich);
        }

        private void ChkÆgBaconSandwich_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkÆgBaconSandwich, btnPlusÆgBacon, btnMinusÆgBacon, txtAntalÆgBacon);
        }

        private void ChkRoastbeefSandwich_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkRoastbeefSandwich, btnPlusRoastbeefSandwich, btnMinusRoastbeefSandwich, txtAntalRoastbeefSandwich);
        }

        private void ChkStegSandwich_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkStegSandwich, btnPlusStegSandwich, btnMinusStegSandwich, txtAntalStegSandwich);
        }

        private void ChkFrikadelleSandwich_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkFrikadelleSandwich, btnPlusFrikadelleSandwich, btnMinusFrikadelleSandwich, txtAntalFrikadelleSandwich);
        }

        private void ChkSkinkeOstSandwich_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkSkinkeOstSandwich, btnPlusSkinkeOst, btnMinusSkinkeOst, txtAntalSkinkeOst);
        }

        private void ChkRøgetLaks_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkRøgetLaks, btnPlusRøgetLaksSandwich, btnMinusRøgetLaksSandwich, txtAntalRøgetLaksSandwich);
        }

        private void ChkÆgRejerSandwich_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkÆgRejerSandwich, btnPlusÆgRejerSandwich, btnMinusÆgRejerSandwich, txtAntalÆgRejerSandwich);
        }

        private void ChkTunsalatSandwich_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkTunsalatSandwich, btnPlusTunsalat, btnMinusTunsalat, txtAntalTunsalat);
        }

        private void ChkSeranoSandwich_Click(object sender, RoutedEventArgs e)
        {
            enabledDisabled(chkSeranoSandwich, btnPlusSeranoSandwich, btnMinusSeranoSandwich, txtAntalSeranoSandwich);
        }


        #endregion

       
    }
}