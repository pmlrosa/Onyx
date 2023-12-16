import PropTypes from 'prop-types';

export default function VatVerifyButton({onClick}) {
    return (
        <button onClick={onClick} >
            Verify vat number
        </button>
    );
}

VatVerifyButton.propTypes = {
    onClick: PropTypes.func
};