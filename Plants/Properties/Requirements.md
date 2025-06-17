# 🌱 Especificación de Requisitos - "Chill Plant Manager"

## 📌 Descripción General

*"Chill Plant Manager"* (nombre interno de proyecto "Plants") es un juego relajado donde los jugadores gestionan el crecimiento de sus plantas. El crecimiento ocurre de forma pasiva con el tiempo, pero los jugadores pueden intervenir para optimizar y acelerar el proceso.

El objetivo es cultivar plantas desde su estado inicial (semilla) hasta la floración, momento en el cual producen nuevas semillas para expandir el jardín con nuevos vegetales.

Avanzar ante ciertos logros o eventos permitirá hacerse con semillas de diferentes plantas.

---

## 🎮 Mecánicas Principales

### 🌿 Crecimiento de las Plantas

- Cada planta pasa por varias fases de crecimiento:
  **Semilla → Brote → Tallo -> Con hojas → Floración -> Marchita**
- Cuando la planta está marchita, hay que retirarla de la maceta.
  - La planta no se puede retirar si no está marchita.
- El cambio entre fases ocurre después de un número determinado de **ciclos de crecimiento pasivo**.
- Cada fase tiene un aspecto visual distinto y un tiempo de crecimiento asociado.
- Ese tiempo de crecimiento cada vez es mayor y se corresponde con la fase de la planta.
  - Si por ejemplo está en fase Planta Joven, el tiempo de crecimiento a Planta Adulta es de tres ciclos.
- **Regar una maceta** hace que la planta crezca según pase el tiempo (durante un día, la maceta estará mojada).
  - Dicho de otro modo, una planta no crece aunque pase el tiempo si su maceta no estaba regada.
- **Abonar la maceta** hace que la planta crezca más rápido.
  - Por el momento hemos decidido que sea un 150% de rápido. Las cifras dependerán a futuro del abono usado.

### ⏳ Gestión del Tiempo de Crecimiento

El juego permite dos modos para gestionar el paso del tiempo:

1. **Modo Manual**:

   - El crecimiento pasivo está pausado.
   - El jugador decide cuándo avanzar un ciclo presionando un botón.
2. **Modo Automático**:

   - El juego avanza un ciclo de crecimiento cada cinco segundos en tiempo real.
     - Hemos visto que no tenemos muy claro estos cinco segundos. Iremos probando esa cifra.
   - El jugador puede activar o desactivar este modo en cualquier momento.

### 🌟 Futuras Mejoras que se espera implementar

- Herramientas o mejoras que incrementan la velocidad del crecimiento pasivo.
  - Hemos añadido aquí el abono de momento, estamos experimentando aún con cómo usarlo.
  - Sabemos que esto será muy cambiante todavía.
- Sistemas automatizados de riego para optimizar el cultivo.
- Time warping.
- Diferentes tipos de plantas con fases y tiempos distintos.
  - Ejemplo: los cactus requieren mucha menos agua.
  - Otro ejemplo: algunas plantas no tienen fase con hojas.
  - Otro ejemplo más: algunas plantas no tienen fase de floración.
- Diferentes tipos de requisitos para que una planta pase a su siguiente fase.
- Eventos aleatorios que afectan el crecimiento de las plantas.
- Mecánicas de interacción con las plantas más allá de regarlas: podar, etc.
- Mecánicas de interacción con el jardín: decoración, iluminación, etc.
  - Ejemplo: los hongos no crecen bien en la iluminación, las plantas necesitan cierta cantidad de luz para crecer.
- Trasplantar de una maceta a otra, o lo que es lo mismo, retirar aunque la planta no esté marchita.

---
