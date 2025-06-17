# 🌱 Especificación de Requisitos - "Chill Plant Manager"

## 📌 Descripción General

*"Chill Plant Manager"* (nombre interno de proyecto "Plants") es un juego relajado donde los jugadores gestionan el crecimiento de sus plantas. El crecimiento ocurre de forma pasiva con el tiempo, pero los jugadores pueden intervenir para optimizar y acelerar el proceso.

El objetivo es cultivar plantas desde su estado inicial (semilla) hasta la floración, momento en el cual producen nuevas semillas para expandir el jardín con nuevos vegetales.

Avanzar ante ciertos logros o eventos permitirá hacerse con semillas de diferentes plantas.

---

## 🎮 Mecánicas Principales

### 🌿 Crecimiento de las Plantas

- Cada planta pasa por varias fases de crecimiento:
  **Semilla → Brote → Tallo -> Con hojas → Floración** ¿¿pregunta: no se marchita??
- El cambio entre fases ocurre después de un número determinado de **ciclos de crecimiento pasivo**.
- Cada fase tiene un aspecto visual distinto y un tiempo de crecimiento asociado.
- Ese tiempo de crecimiento cada vez es mayor y se corresponde con la fase de la planta.
  - Si por ejemplo está en fase Planta Joven, el tiempo de crecimiento a Planta Adulta es de tres ciclos.
- **Regar una planta** acelera temporalmente su crecimiento (durante un día, crecerá al doble de velocidad).
  - Esto está sin especificar bien, cómo leches va. Dandos ejemplos o algo.

### ⏳ Gestión del Tiempo de Crecimiento

El juego permite dos modos para gestionar el paso del tiempo:

1. **Modo Manual**:

   - El crecimiento pasivo está pausado.
   - El jugador decide cuándo avanzar un ciclo presionando un botón.
2. **Modo Automático**:

   - El juego avanza un ciclo de crecimiento cada cinco segundos en tiempo real.
   - El jugador puede activar o desactivar este modo en cualquier momento.

### 🌟 Futuras Mejoras que se espera implementar

- Herramientas o mejoras que incrementan la velocidad del crecimiento pasivo.
- Sistemas automatizados de riego para optimizar el cultivo.
- Time warping.
- Diferentes tipos de plantas con fases y tiempos distintos.
  - Ejemplo: los cactus requieren mucha menos agua.
- Diferentes tipos de requisitos para que una planta pase a su siguiente fase.
- Eventos aleatorios que afectan el crecimiento de las plantas.
- Mecánicas de interacción con las plantas más allá de regarlas: podar, fertilizar, etc.
- Mecánicas de interacción con el jardín: decoración, iluminación, etc.
  - Ejemplo: los hongos no crecen bien en la iluminación, las plantas necesitan cierta cantidad de luz para crecer.

---
