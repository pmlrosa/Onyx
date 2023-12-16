//import React from 'react';
import PropTypes from 'prop-types';
import './VatNumberStatus.css';


function GetDivClassName(status) {
    if (status == 0) {
        return "valid";
    }
    else {
        return "invalid";
    }
}

function GetStatusText(status) {
    switch (status) {
        case 0: return 'Vat number is valid';
        case 1: return 'Vat number is invalid';
        default: return 'Service is unavailable';
    }
}

function VatNumberStatus({ status, showVatStatus }) {
    if (showVatStatus) {
        return (
            <div className={GetDivClassName(status)}>
                {GetStatusText(status)}
            </div>
        );
    }
}

//Example on how to use the switch statement inside the return
//function VatNumberStatus({ status }) {
//    return (
//        <div>
//            {(() => {
//                    switch (status) {
//                        case 0: return 'Vat number is valid';
//                        case 1: return 'Vat number is invalid';
//                        default: return 'Service is unavailable';
//                    }
//                }
//            )()}
//        </div>
//  );
//}

VatNumberStatus.propTypes = {
    status: PropTypes.number,
    showVatStatus: PropTypes.bool,
};

export default VatNumberStatus;