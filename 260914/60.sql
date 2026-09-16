SELECT point, SUM(COALESCE(inc, 0)) - SUM(COALESCE(out, 0)) AS balance FROM (
SELECT point, inc, 0 AS out
FROM Income_o
WHERE date < '2001-04-15'
UNION ALL
SELECT point, 0 AS inc, out
FROM Outcome_o
WHERE date < '2001-04-15')
AS t
GROUP BY point