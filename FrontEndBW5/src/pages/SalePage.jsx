import { useState, useEffect } from "react";
import SaleList from "../components/Pharmacy/Sale/SaleList";
import SaleForm from "../components/Pharmacy/Sale/SaleForm";
import {
  getAllSales,
  addSale,
  updateSale,
  deleteSale,
} from "../services/saleService";

function SalePage() {
  const [sales, setSales] = useState([]);
  const [showForm, setShowForm] = useState(false);
  const [editingSale, setEditingSale] = useState(null);

  const loadSales = async () => {
    const data = await getAllSales();
    setSales(data);
  };

  useEffect(() => {
    loadSales();
  }, []);

  const handleEdit = (sale) => {
    setEditingSale(sale);
    setShowForm(true);
  };

  const handleSave = async (saleData) => {
    const success = editingSale
      ? await updateSale(saleData)
      : await addSale(saleData);

    if (success) {
      await loadSales();
      setShowForm(false);
      setEditingSale(null);
    } else {
      alert("Errore durante il salvataggio.");
    }
  };

  const handleCancel = () => {
    setShowForm(false);
    setEditingSale(null);
  };

  const handleDelete = async (id) => {
    if (window.confirm("Sei sicuro di voler eliminare questa vendita?")) {
      const success = await deleteSale(id);
      if (success) {
        alert("Vendita eliminata con successo.");
        await loadSales();
      } else {
        alert("Errore durante l'eliminazione.");
      }
    }
  };

  return (
    <div className="container mt-4">
      <h2>Gestione Vendite</h2>

      {!showForm && (
        <button
          className="btn btn-primary my-3"
          onClick={() => {
            setEditingSale(null);
            setShowForm(true);
          }}
        >
          Aggiungi nuova vendita
        </button>
      )}

      {showForm && (
        <SaleForm
          initialData={editingSale}
          onSave={handleSave}
          onCancel={handleCancel}
        />
      )}

      <SaleList sales={sales} onEdit={handleEdit} onDelete={handleDelete} />
    </div>
  );
}

export default SalePage;
