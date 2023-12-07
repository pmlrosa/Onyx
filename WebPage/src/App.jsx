import { useState } from 'react'
import './App.css'

function App() {
    const [countryCode, setCountryCode] = useState("");
    const [vatId, setVatId] = useState("");

    const VerifyVatNumber = () => {        
        var apiUrl = "http://localhost:5118/api/vatverifier";

        fetch(apiUrl + "?countryCode=" + countryCode + "&vatId=" + vatId, { method: 'GET' })
            .then(resp => resp.json())
            .then(data => {
                switch (data) {
                    case 0: alert("Vat number is valid");
                        break;
                    case 1: alert("Vat number is invalid");
                        break;
                    default: alert("Service is unavailable");
                        break;
                }
            });
    }

    return (
        <>
            <table className="divMain">
                <tbody>
                    <tr>
                        <td>
                            Country code
                        </td>
                        <td>
                            <input type="text" placeholder="2 letters required"
                                onChange={event => setCountryCode(event.target.value)}
                                minLength="2" maxLength="2"></input>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Vat number
                        </td>
                        <td>
                            <input type="text" onChange={event => setVatId(event.target.value)}
                                minLength="2" maxLength="12"
                                placeholder="Min 2 and Max 12 digits or letters"></input>
                        </td>
                    </tr>
                </tbody>
            </table>

            <br />

            <button onClick={VerifyVatNumber} >
                Verify vat number
            </button>
    </>
    )
}
export default App
