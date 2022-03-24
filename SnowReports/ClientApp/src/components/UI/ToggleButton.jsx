import React, {useEffect, useState} from 'react';
import styles from './ToggleButton.module.css';

const ToggleButton = ( {defaultChecked, onChange}) => {
    const [toggle, setToggle] = useState(false);

    useEffect(() => {
        if (defaultChecked) {
            setToggle(defaultChecked);
        }
    }, [defaultChecked]);

    const triggerToggle = () => {
        setToggle( !toggle )
        if ( typeof onChange === 'function' ) {
            onChange(!toggle);
        }
    }

    return (
        <div className={`${styles.wrgToggle} ${toggle ? styles.wrgToggleChecked : ''}`} onClick={triggerToggle}>
            <div className={styles.wrgToggleContainer}>
                <div className={styles.wrgToggleCheck}>
                    <span></span>
                </div>
                <div className={styles.wrgToggleUncheck}>
                    <span></span>
                </div>
            </div>
            <div className={styles.wrgToggleCircle}></div>
            <input className={styles.wrgToggleInput} type="checkbox" aria-label="Toggle Button" />
        </div>
    );
};

export default ToggleButton;