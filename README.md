# Mean-Field Theory (MFT) Simulation of Spin Systems in C#

This repository presents an interactive simulation of spin systems using **Mean-Field Theory (MFT)** implemented in C#. The simulation demonstrates how spins in a magnetic system interact collectively, approximating the effect of all other spins on a single spin as an average field. MFT simplifies the complex many-body problem while still capturing essential physics, such as **phase transitions** and **spontaneous magnetization**.

[GitHub Repository](https://github.com/FatimaIjazOfficial/MEAN-FIELD-THEORY-MFT-)

The program visualizes key aspects of MFT through several plots and analytical results, bridging theoretical physics with intuitive graphical representation.

---

## 🔬 Project Details

### MFT Equation

The central MFT equation for an Ising spin system is:

s = tanh(z * s / T)

Where:

* **s** : average spin (magnetization per site)
* **z** : coordination number (number of nearest neighbors per spin)
* **T** : temperature (controls thermal fluctuations)

The equation is nonlinear. Graphical methods and fixed-point analysis are used to find solutions **s** for a given temperature **T**.

---

### Graphical Illustrations

**1. s vs s**

* Simple linear identity, y = s, serving as a reference line.
* Purpose: Provides a baseline for comparison against the nonlinear function s = tanh(z*s/T).

**2. s vs tanh(z*s/T)**

* Plots the nonlinear MFT function y = tanh(z*s/T).
* Purpose: Shows how spins respond to the average field at a given temperature.
* Observation: Intersections with y = s indicate fixed points (possible magnetization states).

**3. s vs s - tanh(z*s/T)**

* Plots the difference function y = s - tanh(z*s/T).
* Purpose: Fixed points occur where this function crosses zero (y = 0), identifying stable and unstable magnetization states.

**4. Analytical Spontaneous Magnetization s(T)**

* For temperatures below the critical temperature T_c = z, spontaneous magnetization appears:

s(T) = ± sqrt(T_c - T)

* Purpose: Illustrates phase transition, where the system acquires nonzero magnetization spontaneously below T_c.
* Observation: Two branches (+s and -s) appear, reflecting symmetry of spin alignment.

**5. s vs T (Fixed Points)**

* Shows temperature dependence of fixed points.
* Purpose: Visualizes how magnetization changes with temperature.
* Observation: At high temperatures, only the trivial solution s = 0 exists (disordered phase). Below T_c, nonzero magnetization emerges (ordered phase).

---

## 🧪 Results & Observations

* **s vs s:** Straight line, reference.
* **s vs tanh(z*s/T):** Nonlinear, intersections indicate possible magnetization states.
* **s vs s - tanh(z*s/T):** Zeros correspond to fixed points.
* **Spontaneous Magnetization:** Emerges below critical temperature; shows phase transition.
* **s vs T (Fixed Points):** Highlights stable and unstable states as a function of temperature.

---

## ✅ Conclusion

"The MFT simulation demonstrates how individual spin interactions can be approximated by an average field to reveal collective behavior. This simulation provides an interactive and visual way to explore phase transitions and mean-field physics in spin systems."

Key insights:

1. **Above critical temperature:** Only the trivial solution s = 0 exists (disordered phase).
2. **Below critical temperature:** Two nonzero solutions appear, representing spontaneous magnetization (ordered phase).

By visualizing the nonlinear MFT equation and fixed points, the simulation bridges theory and intuition in statistical physics.

---

## ⚙️ Numerical Techniques Used

* Nonlinear Equation Visualization
* Fixed-Point Analysis
* Analytical Spontaneous Magnetization Computation
* Temperature-Dependent Phase Transition Analysis

---

## 🧮 Technologies

* **Language:** C#
* **Framework:** .NET (Windows Forms)
* **Graphics:** GDI+ (System.Drawing)
* **Environment:** Visual Studio

---

## 🧠 Educational Purpose

This simulation helps learners:

* Understand collective behavior in spin systems.
* Explore phase transitions and spontaneous magnetization.
* Visualize nonlinear mean-field equations and fixed points.
* Connect theoretical statistical physics with interactive simulations.

---

## 🔗 Website Reference

Detailed write-ups and visual demonstrations: [Fatima Ijaz C# Projects](https://sites.google.com/view/fatima-ijaz/c-projects)

---

## 📜 Author

**Fatima Ijaz**
BS in Computational Physics — University of the Punjab
Focused on Computational Physics and Scientific Simulations
Certified: 100 Days of Code – The Complete Python Pro Bootcamp by Dr. Angela Yu
