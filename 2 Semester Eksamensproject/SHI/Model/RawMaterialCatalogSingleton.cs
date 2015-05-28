using System.Collections.ObjectModel;
using SHI.Model.Persistency;

namespace SHI.Model
{
    public class RawMaterialCatalogSingleton
    {
        private static RawMaterialCatalogSingleton _instance = new RawMaterialCatalogSingleton();

        public static RawMaterialCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new RawMaterialCatalogSingleton()); }
        }

        public ObservableCollection<RawMaterial> RawMaterials { get; set; }

        private RawMaterialCatalogSingleton()
        {
            RawMaterials = new ObservableCollection<RawMaterial>();
        }

        public async void LoadRawMaterialsAsync()
        {
            var rawMaterials = await PersistencyService.LoadRawMaterialsFromJsonAsync();
            if (rawMaterials != null)
            {
                foreach (var rawMaterial in rawMaterials)
                {
                    RawMaterials.Add(rawMaterial);
                }
            }
        }

        public bool CheckRawMaterial(string name)
        {
            var check = true;
            foreach (var rawMaterial in RawMaterials)
            {
                if (rawMaterial.Name == name)
                {
                    check = false;
                }
            }
            return check;
        }
        public void AddRawMaterial(RawMaterial rawMaterial)
        {
            RawMaterials.Add(rawMaterial);
            PersistencyService.SaveRawMaterialsAsJsonAsync(rawMaterial);
        }

        public void AddRawMaterial(int amount, string description, int id, string name)
        {
            RawMaterial rawMaterial = new RawMaterial(amount, description, id, name);
            RawMaterials.Add(rawMaterial);
            PersistencyService.SaveRawMaterialsAsJsonAsync(rawMaterial);
        }

        public void RemoveRawMaterial(RawMaterial rawMaterial)
        {
            RawMaterials.Remove(rawMaterial);
            PersistencyService.DeleteRawMaterialsAsync(rawMaterial);
        }
    }
}
