using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KANTAR_BPI_BATCHING_v1._0
{
    public class EntryTable
    {
        private int batchTblId;
        private string pullout;
        private string barcode;
        private string productName;
        private string preparation;
        private string energy_kj;
        private string energy_kcal;
        private string protein;
        private string carbohydrates;
        private string sugar;
        private string fat;
        private string saturates;
        private string mono_unsaturates;
        private string poly_unsaturates;
        private string fiber;
        private string soduim;
        private string salt;


        public EntryTable(int batchTblId, string pullout, string barcode, string productName, string preparation, string energy_kj, string energy_kcal,
            string protein, string carbohydrates, string sugar, string fat, string saturates, string mono_unsaturates, string poly_unsaturates,
            string fiber, string soduim, string salt) 
        {
            this.batchTblId = batchTblId;
            this.pullout = pullout;
            this.barcode = barcode;
            this.productName = productName;
            this.preparation = preparation;
            this.energy_kj = energy_kj;
            this.energy_kcal = energy_kcal;
            this.protein = protein;
            this.carbohydrates = carbohydrates;
            this.sugar = sugar;
            this.fat = fat;
            this.saturates = saturates;
            this.mono_unsaturates = mono_unsaturates;
            this.poly_unsaturates= poly_unsaturates;
            this.fiber = fiber;
            this.soduim = soduim;
            this.salt = salt;
        }



        public int GetBatchTblId 
        {  
            get { return batchTblId; } 
            set { batchTblId = value; }
        }

        public string Getpullout
        {
            get { return pullout; }
            set { pullout = value; }
        }

        public string GetBarcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        public string GetProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public string GetPreparation
        {
            get { return preparation; }
            set { preparation = value; }
        }
        public string GetEnergyKJ
        {
            get { return energy_kj; }
            set { energy_kj = value; }
        }

        public string GetEnergy_Kcal
        {
            get { return energy_kcal; }
            set { energy_kcal = value; }
        }
        public string GetProtein
        {
            get { return protein; }
            set { protein = value; }
        }

        public string GetCarbohydrates
        {
            get { return carbohydrates; }
            set { carbohydrates = value; }
        }

        public string GetSugar
        {
            get { return sugar; }
            set { sugar = value; }
        }

        public string GetFat
        {
            get { return fat; }
            set { fat = value; }
        }

        public string GetSaturates
        {
            get { return saturates; }
            set { saturates = value; }
        }

        public string GetMonoUnsaturates
        {
            get { return mono_unsaturates; }
            set {  mono_unsaturates = value; }
        }
        
        public string GetPolyUnsaturates
        {
            get { return poly_unsaturates; }
            set { poly_unsaturates = value; }
        }

        public string GetFiber
        {
            get { return fiber; }
            set { fiber = value; }
        }

        public string GetSodium
        {
            get { return soduim; } 
            set { soduim = value; }
        }

        public string GetSalt
        {
            get { return salt; }
            set { salt = value; }
        }

    }
}
