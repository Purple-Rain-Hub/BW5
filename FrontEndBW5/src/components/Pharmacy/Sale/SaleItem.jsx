function SaleItem({ sale, onEdit, onDelete }) {
  const formatDate = (dateString) => {
    if (!dateString) return "—";
    const date = new Date(dateString);
    return date.toLocaleDateString();
  };

  return (
    <div className="card h-100">
      <div className="card-body">
        <h5 className="card-title">Vendita #{sale.id}</h5>
        <p className="card-text">
          <strong>Cliente (CF):</strong> {sale.customerFiscalCode}
        </p>
        <p className="card-text">
          <strong>Data:</strong> {formatDate(sale.saleDate)}
        </p>
        <p className="card-text">
          <strong>Ricetta:</strong> {sale.prescriptionNumber ?? "Nessuna"}
        </p>

        <div className="d-flex justify-content-end gap-2">
          <button className="btn btn-outline-primary btn-sm" onClick={() => onEdit(sale)}>
            Modifica
          </button>
          <button
            className="btn btn-outline-danger btn-sm"
            onClick={() => {
              if (window.confirm("Sei sicuro di voler eliminare questa vendita?")) {
                onDelete(sale.id);
              }
            }}
          >
            Elimina
          </button>
        </div>
      </div>
    </div>
  );
}

export default SaleItem;
