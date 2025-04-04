import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';

function MedicineItem({ medicine, onDelete, onEdit }) {
  return (
    <Card style={{ width: '18rem' }}>
      <Card.Header>{medicine.name}</Card.Header>
      <ListGroup variant="flush">
        <ListGroup.Item>ID: {medicine.id}</ListGroup.Item>
        <ListGroup.Item>Company: {medicine.supplierCompany}</ListGroup.Item>
        <ListGroup.Item>Usage: {medicine.usageList}</ListGroup.Item>
        <ListGroup.Item>Storage Location: {medicine.storageLocationId}</ListGroup.Item>
        <ListGroup.Item>Prescription Required: {medicine.requiresPrescription ? 'Yes' : 'No'}</ListGroup.Item>
        <ListGroup.Item>Available: {medicine.isAvailable ? 'Yes' : 'No'}</ListGroup.Item>
        <ListGroup.Item>Price: € {medicine.price?.toFixed(2)}</ListGroup.Item>
      </ListGroup>
      <div className="d-flex justify-content-between">
          <button className="btn btn-primary btn-sm" onClick={() => onEdit(medicine)}>Modifica</button>
          <button className="btn btn-danger btn-sm" onClick={() => onDelete(medicine.id)}>Elimina</button>
      </div>
    </Card>
  );
}

export default MedicineItem;
