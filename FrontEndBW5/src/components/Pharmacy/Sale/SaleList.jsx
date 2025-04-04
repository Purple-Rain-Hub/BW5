import SaleItem from "./SaleItem";

function SaleList({ sales, onEdit, onDelete }) {
  return (
    <div>
      <h2 className="mb-4">Lista Vendite</h2>

      {sales.length === 0 ? (
        <p>Nessuna vendita trovata.</p>
      ) : (
        <div className="row">
          {sales.map((sale) => (
            <div key={sale.id} className="col-md-4 mb-3">
              <SaleItem sale={sale} onEdit={onEdit} onDelete={onDelete} />
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default SaleList;
