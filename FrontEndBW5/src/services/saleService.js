const BASE_URL = "https://localhost:7030/api/Sale";

const token =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBjbGluaWNhLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJBZG1pbiBBZG1pbiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzQ5NzU2MTQ4LCJpc3MiOiJodHRwczovL3N0dWRlbnRBcGkuY29tIiwiYXVkIjoiaHR0cHM6Ly9zdHVkZW50QXBpLmNvbSJ9.8lwjMbOuEAb8rsTLCTK65bIde1j0JQemromMXgZP9C0";

const authHeaders = {
  Authorization: `Bearer ${token}`,
};

export async function getAllSales() {
  try {
    const response = await fetch(BASE_URL, {
      headers: {
        ...authHeaders,
      },
    });

    if (!response.ok) throw new Error("Errore nel caricamento delle vendite");

    return await response.json();
  } catch (error) {
    console.error("Errore fetch vendite:", error);
    return [];
  }
}

export async function addSale(newSale) {
  try {
    const response = await fetch("https://localhost:7030/api/Sale", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(newSale),
    });

    if (!response.ok) throw new Error("Errore nella creazione della vendita");

    return true;
  } catch (error) {
    console.error("Errore creazione vendita:", error);
    return false;
  }
}

export async function updateSale(sale) {
  try {
    const response = await fetch("https://localhost:7030/api/Sale", {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(sale),
    });

    if (!response.ok)
      throw new Error("Errore nell'aggiornamento della vendita");

    return true;
  } catch (error) {
    console.error("Errore aggiornamento vendita:", error);
    return false;
  }
}

export async function deleteSale(id) {
    try {
      const response = await fetch(`https://localhost:7030/api/Sale/${id}`, {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
  
      return response.ok;
    } catch (error) {
      console.error("Errore eliminazione vendita:", error);
      return false;
    }
  }
  
