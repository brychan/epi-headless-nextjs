"use client";
import React, { useEffect, useState } from "react";
import styles from "./CoinDeskData.module.css";

interface CurrencyData {
  code: string;
  symbol: string;
  rate: string;
  description: string;
  rate_float: number;
}

interface CoinDeskResponse {
  time: {
    updated: string;
    updatedISO: string;
    updateduk: string;
  };
  disclaimer: string;
  chartName: string;
  bpi: {
    [key: string]: CurrencyData;
  };
}

const getData = async (): Promise<CoinDeskResponse> => {
  let res = await fetch("https://api.coindesk.com/v1/bpi/currentprice.json");
  await new Promise((resolve) => setTimeout(resolve, 2000));
  return res.json();
};

const CoinDeskData: React.FC = async () => {
  let { time, disclaimer, bpi, chartName } = await getData();

  return (
    <div>
      <h3>Time Updated: {time?.updated}</h3>
      <h4>BPI (Bitcoin Price Index):</h4>
      <div className={styles.cardContainer}>
        {Object.entries(bpi).map(
          ([currency, { code, symbol, rate, description, rate_float }]) => (
            <div className={styles.card} key={currency}>
              <h5>{currency}</h5>
              <p>Code: {code}</p>
              <h3>
                {rate} {code}
              </h3>
              <p>Description: {description}</p>
              <p>Rate Float: {rate_float}</p>
            </div>
          )
        )}
      </div>
    </div>
  );
};

export default CoinDeskData;
