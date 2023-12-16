import { useState } from 'react'
import './App.css'
import VatNumberStatus from './VatNumberStatus';
import VatVerifyButton from './VatVerifyButton';

export default function App() {
    const [countryCode, setCountryCode] = useState("");
    const [vatId, setVatId] = useState("");
    const [vatStatus, setVatStatus] = useState(-1);
    const [showVatStatus, setShowVatStatus] = useState(false);

    function handleVerifyButton() {        
        var apiUrl = "http://localhost:5118/api/vatverifier";

        try {
            fetch(apiUrl + "?countryCode=" + countryCode + "&vatId=" + vatId, { method: 'GET' })
                .then(resp => resp.json())
                .then(data => {
                    setVatStatus(data);
                    setShowVatStatus(true);
                });
        } catch (e) {
            setVatStatus(-1);
            setShowVatStatus(true);
        }
    }

    function UpdateCountryCode(countryCode) {
        setCountryCode(countryCode);
        setShowVatStatus(false);
    }

    function UpdateVatId(vatId) {
        setVatId(vatId);
        setShowVatStatus(false);
    }

    return (
        <>
            <table>
                <tbody>
                    <tr>
                        <td>
                            Country code
                        </td>
                        <td>
                            <input type="text" placeholder="2 letters required"
                                onChange={event => UpdateCountryCode(event.target.value)}
                                minLength="2" maxLength="2"></input>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Vat number
                        </td>
                        <td>
                            <input type="text" onChange={event => UpdateVatId(event.target.value)}
                                minLength="2" maxLength="12"
                                placeholder="Min 2 and Max 12 digits or letters"></input>
                        </td>
                    </tr>
                </tbody>
            </table>

            <br />
            <VatVerifyButton onClick={handleVerifyButton } />
            
            <br />
            <VatNumberStatus status={vatStatus} showVatStatus={showVatStatus} />
    </>
    )
}