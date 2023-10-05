import { useEffect, useState } from "react"

const useFetch = (url) => {

    const [data, setData] = useState(null);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch(url)
            .then(res => {
                if (!res) {
                    throw Error('Greška pri dobavljanju podataka');
                }
                return res.json();
            })
            .then(data => {
                setData(data);
                setError(null);
            })
            .catch(err => {
                setError(err.message);
            })
    }, [url])

    return {data, error};
}

export default useFetch;