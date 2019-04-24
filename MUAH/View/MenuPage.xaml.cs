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

            txtKoldtbord.Visibility = Visibility.Collapsed;
            txtBuffet.Visibility = Visibility.Collapsed;
            txtSandwich.Visibility = Visibility.Collapsed;
            txtSmørrebrød.Visibility = Visibility.Collapsed;
            txtTapas.Visibility = Visibility.Collapsed;
            txtBrunch.Visibility = Visibility.Collapsed;

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

                txtKoldtbord.Visibility = Visibility.Collapsed;
                txtBrunch.Visibility = Visibility.Collapsed;
                txtBuffet.Visibility = Visibility.Collapsed;
                txtSandwich.Visibility = Visibility.Collapsed;
                txtSmørrebrød.Visibility = Visibility.Collapsed;
                txtTapas.Visibility = Visibility.Collapsed;
            }

            foreach (var items in myPanels)
            {
                items.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnSmørrebrød_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlSmørrebrød);
            txtSmørrebrød.Visibility = Visibility.Visible;
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
            txtBrunch.Visibility = Visibility.Visible;
        }

        private void BtnTapas_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlTapas);
            txtTapas.Visibility = Visibility.Visible;
        }

        private void BtnSalater_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlSalater);
        }

        private void BtnSandwich_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlSandwich);
            txtSandwich.Visibility = Visibility.Visible;
        }

        private void BtnKoldtbord_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlKoldtbord);
            txtKoldtbord.Visibility = Visibility.Visible;
        }

        private void BtnSpecials_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlSpecials);
        }

        private void BtnBuffet_Click_1(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlBuffet);
            txtBuffet.Visibility = Visibility.Visible;
        }

        #endregion     

        #region Plus/Minus smørrebrød rugbrød

        private void BtnPlusHåndmadderUspecificeretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHåndmadderUspecificeretRugbrød.Text = addAntal(txtHåndmadderUspecificeretRugbrød.Text);
        }

        private void BtnMinusHåndmadderUspecificeretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHåndmadderUspecificeretRugbrød.Text = subAntal(txtHåndmadderUspecificeretRugbrød.Text);
        }

        private void BtnPlusHåndmadderSpecificeretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHåndmadderSpecificeretRugbrød.Text = addAntal(txtHåndmadderSpecificeretRugbrød.Text);
        }

        private void BtnMinusHåndmadderSpecificeretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHåndmadderSpecificeretRugbrød.Text = subAntal(txtHåndmadderSpecificeretRugbrød.Text);
        }

        private void BtnPlusHøjtbelagtRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHøjbelagtRugbrød.Text = addAntal(txtHøjbelagtRugbrød.Text);
        }

        private void BtnMinusHøjtbelagtRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHøjbelagtRugbrød.Text = subAntal(txtHøjbelagtRugbrød.Text);
        }

        private void BtnPlusÆgTomatRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtÆgTomatRugbrød.Text = addAntal(txtÆgTomatRugbrød.Text);
        }

        private void BtnMinusÆgTomatRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtÆgTomatRugbrød.Text = subAntal(txtÆgTomatRugbrød.Text);
        }

        private void BtnPlusÆgRejerRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtÆgRejerRugbrød.Text = addAntal(txtÆgRejerRugbrød.Text);
        }

        private void BtnMinusÆgRejerRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtÆgRejerRugbrød.Text = subAntal(txtÆgRejerRugbrød.Text);
        }

        private void BtnPlusRullepølseRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtRullepølseRugbrød.Text = addAntal(txtRullepølseRugbrød.Text);
        }

        private void BtnMinusRullepølseRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtRullepølseRugbrød.Text = subAntal(txtRullepølseRugbrød.Text);
        }

        private void BtnPlusFrikadelleRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFrikadelleRugbrød.Text = addAntal(txtFrikadelleRugbrød.Text);
        }

        private void BtnMinusFrikadlleRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFrikadelleRugbrød.Text = subAntal(txtFrikadelleRugbrød.Text);
        }

        private void BtnPlusFlæskestegRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFlæskestegRgbrød.Text = addAntal(txtFlæskestegRgbrød.Text);
        }

        private void BtnMinusFlæskestegRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFlæskestegRgbrød.Text = subAntal(txtFlæskestegRgbrød.Text);
        }

        private void BtnPlusLeverpostejRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtLeverposteRugbrød.Text = addAntal(txtLeverposteRugbrød.Text);
        }

        private void BtnMinusLeverpostejRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtLeverposteRugbrød.Text = subAntal(txtLeverposteRugbrød.Text);
        }

        private void BtnPlusDyrlægensRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtDyrlægensRugbrød.Text = addAntal(txtDyrlægensRugbrød.Text);
        }

        private void BtnMinusDyrlægensRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtDyrlægensRugbrød.Text = subAntal(txtDyrlægensRugbrød.Text);
        }

        private void BtnPlusRoastbeefRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtRoastbeefRugbrød.Text = addAntal(txtRoastbeefRugbrød.Text);
        }

        private void BtnMinusRoastbeefRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtRoastbeefRugbrød.Text = subAntal(txtRoastbeefRugbrød.Text);
        }

        private void BtnPlusFiskefiletRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFiskefiletRugbrød.Text = addAntal(txtFiskefiletRugbrød.Text);
        }

        private void BtnMinusFiskefiletRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFiskefiletRugbrød.Text = subAntal(txtFiskefiletRugbrød.Text);
        }

        private void BtnPlusStjernekasterRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtStjernekasterRugbrød.Text = addAntal(txtStjernekasterRugbrød.Text);
        }

        private void BtnMinusStjernekasterRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtStjernekasterRugbrød.Text = subAntal(txtStjernekasterRugbrød.Text);
        }

        private void BtnPlusStjerneskudRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtStjerneskudRugbrød.Text = addAntal(txtStjerneskudRugbrød.Text);
        }

        private void BtnMinusStjerneskudRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtStjerneskudRugbrød.Text = subAntal(txtStjerneskudRugbrød.Text);
        }

        private void BtnPlusSkinkeRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtSkinkeRugbrød.Text = addAntal(txtSkinkeRugbrød.Text);
        }

        private void BtnMinusSkinkeRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtSkinkeRugbrød.Text = subAntal(txtSkinkeRugbrød.Text);
        }

        private void BtnPlusOksebrystRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtOksebrystRugbrød.Text = addAntal(txtOksebrystRugbrød.Text);
        }

        private void BtnMinusOksebrystRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtOksebrystRugbrød.Text = subAntal(txtOksebrystRugbrød.Text);
        }

        private void BtnPlusKalkunRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtKalkunRugbrød.Text = addAntal(txtKalkunRugbrød.Text);
        }

        private void BtnMinusKalkunRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtKalkunRugbrød.Text = subAntal(txtKalkunRugbrød.Text);
        }

        private void BtnPlusTatarRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtTatarRugbrød.Text = addAntal(txtTatarRugbrød.Text);
        }

        private void BtnMinusTatarRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtTatarRugbrød.Text = subAntal(txtTatarRugbrød.Text);
        }

        private void BtnPlusMørbradRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMørbradRugbrød.Text = addAntal(txtMørbradRugbrød.Text);
        }

        private void BtnMinusMørbradRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMørbradRugbrød.Text = subAntal(txtMørbradRugbrød.Text);
        }

        private void BtnPlusBrieRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtBrieRugbrød.Text = addAntal(txtBrieRugbrød.Text);
        }

        private void BtnMinusBrieRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtBrieRugbrød.Text = subAntal(txtBrieRugbrød.Text);
        }

        private void BtnPlusMellemlageretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMellemlageretRugbrød.Text = addAntal(txtMellemlageretRugbrød.Text);
        }

        private void BtnMinusMellemlageretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMellemlageretRugbrød.Text = subAntal(txtMellemlageretRugbrød.Text);
        }

        private void BtnPlusLageretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtLageretRugbrød.Text = addAntal(txtLageretRugbrød.Text);
        }

        private void BtnMinusLageretRugbrød_Click(object sender, RoutedEventArgs e)
        {
            txtLageretRugbrød.Text = subAntal(txtLageretRugbrød.Text);
        }

        #endregion

        #region Plus/Minus smørrebrød franskbrød

        private void BtnPlusHåndmadderUspecificeretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHåndmadderUspecificeretFranskbrød.Text = addAntal(txtHåndmadderUspecificeretFranskbrød.Text);
        }

        private void BtnMinusHåndmadderUspecificeretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHåndmadderUspecificeretFranskbrød.Text = subAntal(txtHåndmadderUspecificeretFranskbrød.Text);
        }

        private void BtnPlusHåndmadderSpecificeretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHåndmadderSpecificeretFranskbrød.Text = addAntal(txtHåndmadderSpecificeretFranskbrød.Text);
        }

        private void BtnMinusHåndmadderSpecificeretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHåndmadderSpecificeretFranskbrød.Text = subAntal(txtHåndmadderSpecificeretFranskbrød.Text);
        }

        private void BtnPlusHøjtbelagtFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHøjtbelagtFranskbrød.Text = addAntal(txtHøjtbelagtFranskbrød.Text);
        }

        private void BtnMinusHøjtbelagtFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtHøjtbelagtFranskbrød.Text = subAntal(txtHøjtbelagtFranskbrød.Text);
        }

        private void BtnPlusÆgTomatFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtÆgTomatFranskbrød.Text = addAntal(txtÆgTomatFranskbrød.Text);
        }

        private void BtnMinusÆgTomatFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtÆgTomatFranskbrød.Text = subAntal(txtÆgTomatFranskbrød.Text);
        }

        private void BtnPlusÆgRejerFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtÆgRejerFranskbrød.Text = addAntal(txtÆgRejerFranskbrød.Text);
        }

        private void BtnMinusÆgRejerFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtÆgRejerFranskbrød.Text = subAntal(txtÆgRejerFranskbrød.Text);
        }

        private void BtnPlusRullepølseFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtRullepølseFranskbrød.Text = addAntal(txtRullepølseFranskbrød.Text);
        }

        private void BtnMinusRullepølseFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtRullepølseFranskbrød.Text = subAntal(txtRullepølseFranskbrød.Text);
        }

        private void BtnPlusFrikadelleFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFrikadelleFranskbrød.Text = addAntal(txtFrikadelleFranskbrød.Text);
        }

        private void BtnMinusFrikadelleFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFrikadelleFranskbrød.Text = subAntal(txtFrikadelleFranskbrød.Text);
        }

        private void BtnPlusFlæskestegFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFlæskestegFranskbrød.Text = addAntal(txtFlæskestegFranskbrød.Text);
        }

        private void BtnMinusFlæskestegFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFlæskestegFranskbrød.Text = subAntal(txtFlæskestegFranskbrød.Text);
        }

        private void BtnPlusLeverpostejFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtLeverpostejFranskbrød.Text = addAntal(txtLeverpostejFranskbrød.Text);
        }

        private void BtnMinusLeverpostejFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtLeverpostejFranskbrød.Text = subAntal(txtLeverpostejFranskbrød.Text);
        }

        private void BtnPlusDyrlægensFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtDyrlægensFranskbrød.Text = addAntal(txtDyrlægensFranskbrød.Text);
        }

        private void BtnMinusDyrlægensFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtDyrlægensFranskbrød.Text = subAntal(txtDyrlægensFranskbrød.Text);
        }

        private void BtnPlusRoastbeefFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtRoastbeefFranskbrød.Text = addAntal(txtRoastbeefFranskbrød.Text);
        }

        private void BtnMinusRoastbeefFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtRoastbeefFranskbrød.Text = subAntal(txtRoastbeefFranskbrød.Text);
        }

        private void BtnPlusFiskefiletFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFiskefiletFranskbrød.Text = addAntal(txtFiskefiletFranskbrød.Text);
        }

        private void BtnMinusFiskefiletFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtFiskefiletFranskbrød.Text = subAntal(txtFiskefiletFranskbrød.Text);
        }

        private void BtnPlusStjernekasterFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtStjernekasterFranskbrød.Text = addAntal(txtStjernekasterFranskbrød.Text);
        }

        private void BtnMinusStjernekasterFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtStjernekasterFranskbrød.Text = subAntal(txtStjernekasterFranskbrød.Text);
        }

        private void BtnPlusStjerneskudFranskbrød_Click(object sender, RoutedEventArgs e)
        {
           txtStjerneSkudFranskbrød.Text = addAntal(txtStjerneSkudFranskbrød.Text);
        }

        private void BtnMinusStjerneskudFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtStjerneSkudFranskbrød.Text = subAntal(txtStjerneSkudFranskbrød.Text);
        }

        private void BtnPlusSkinkeFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtSkinkeFranskbrød.Text = addAntal(txtSkinkeFranskbrød.Text);
        }

        private void BtnMinusSkinkeFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtSkinkeFranskbrød.Text = subAntal(txtSkinkeFranskbrød.Text);
        }

        private void BtnPlusOksebrystFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtOksebrystFranskbrød.Text = addAntal(txtOksebrystFranskbrød.Text);
        }

        private void BtnMinusOksebrystFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtSkinkeFranskbrød.Text = subAntal(txtSkinkeFranskbrød.Text);
        }

        private void BtnPlusKalkunFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtKalkunFranskbrød.Text = addAntal(txtKalkunFranskbrød.Text);
        }

        private void BtnMinusKalkunFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtKalkunFranskbrød.Text = subAntal(txtKalkunFranskbrød.Text);
        }

        private void BtnPlusTatarFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtTatarFranskbrød.Text = addAntal(txtTatarFranskbrød.Text);
        }

        private void BtnMinusTatarFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtTatarFranskbrød.Text = subAntal(txtTatarFranskbrød.Text);
        }

        private void BtnPlusMørbradFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMørbradFranskbrød.Text = addAntal(txtMørbradFranskbrød.Text);
        }

        private void BtnMinusMørbradFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMørbradFranskbrød.Text = subAntal(txtMørbradFranskbrød.Text);
        }

        private void BtnPlusBrieFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMinusBrieFranskbrød.Text = addAntal(txtMinusBrieFranskbrød.Text);
        }

        private void BtnMinusBrieFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMinusBrieFranskbrød.Text = subAntal(txtMinusBrieFranskbrød.Text);
        }

        private void BtnPlusMellemlageretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMellemlageretFranskbrød.Text = addAntal(txtMellemlageretFranskbrød.Text);
        }

        private void BtnMinusMellemlageretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtMellemlageretFranskbrød.Text = subAntal(txtMellemlageretFranskbrød.Text);
        }

        private void BtnPlusLageretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtLageretFranskbrød.Text = addAntal(txtLageretFranskbrød.Text);
        }

        private void BtnMinusLageretFranskbrød_Click(object sender, RoutedEventArgs e)
        {
            txtLageretFranskbrød.Text = subAntal(txtLageretFranskbrød.Text);
        }
        #endregion

        #region Plus/Minus koldtbord

        private void BtnPlusPlatte_Click(object sender, RoutedEventArgs e)
        {
            txtPlatte.Text = addAntal(txtPlatte.Text);
        }

        private void BtnMinusPlatte_Click(object sender, RoutedEventArgs e)
        {
            txtPlatte.Text = subAntal(txtPlatte.Text);
        }

        private void BtnPlusKoldtbord_Click(object sender, RoutedEventArgs e)
        {
            txtKoldtbord1.Text = addAntal(txtKoldtbord1.Text);
        }

        private void BtnMinusKoldtbord_Click(object sender, RoutedEventArgs e)
        {
            txtKoldtbord1.Text = subAntal(txtKoldtbord1.Text);
        }

        private void BtnPlusLuksusplatte_Click(object sender, RoutedEventArgs e)
        {
            txtLuksusplatte.Text = addAntal(txtLuksusplatte.Text);
        }

        private void BtnMinusLuksusplatte_Click(object sender, RoutedEventArgs e)
        {
            txtLuksusplatte.Text = subAntal(txtLuksusplatte.Text);
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

        
        private void BtnPlusÆblekage_Click(object sender, RoutedEventArgs e)
        {
            txtAntalÆblekage.Text = addAntal(txtAntalÆblekage.Text);
        }

        private void BtnMinusÆblekage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPlusChokolademousse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMinusChokolademousse_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnPlusPassionsmousse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMinusPassionsmousse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPlusSkovbærtærte_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMinusSkovbærtærte_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPlusFriskFrugt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMinusFriskFrugt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPlusHindbærmousse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMinusHindbærmousse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPlusChokoladekage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMinusChokoladekage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPlusBlåbærCheesecake_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMinusBlåbærCheesecake_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChkDessertÆblekage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChkDessertChokolademousse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChkDessertPassionsmousse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChkDessertSkovbærstærte_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChkDessertFriskFrugt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChkDessertHindbærmousse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChkDessertChokoladekage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChkDessertBlåbærCheesecake_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}