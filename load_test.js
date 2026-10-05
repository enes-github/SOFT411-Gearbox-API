import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    vus: 50,
    duration: '30s',
};

export default function () {
    let payload = JSON.stringify({ gear1: 3.166, gear2: 1.882, finalDrive: 4.111 });
    let params = { headers: { 'Content-Type': 'application/json' } };
    
    // Ensure this points to your local running API
    let res = http.post('http://localhost:5000/calculate', payload, params);
    
    check(res, {
        'is status 200': (r) => r.status === 200,
        'transaction time OK': (r) => r.timings.duration < 200,
    });
    sleep(1);
}