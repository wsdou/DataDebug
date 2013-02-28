// -*- C++ -*-

#ifndef STATS_H_
#define STATS_H_

#include <assert.h>
#include <math.h>

#include <vector>
#include <algorithm>
using namespace std;

/*
 * Some basic stats functions over vectors.
 *
 */

namespace stats {

  template <class TYPE>
  TYPE sum (const vector<TYPE>& in) {
    TYPE s = 0;
    for (auto const& x : in) {
      s += x;
    }
    return s;
  }

  template <class TYPE>
  TYPE max (const vector<TYPE>& in) {
    TYPE m = in[0];
    for (auto& x : in) {
      if (x > m) {
	m = x;
      }
    }
    return m;
  }


  template <class TYPE>
  float average (const vector<TYPE>& in) {
    return sum (in) / (float) in.size();
  }

  template <class TYPE>
  float stddev (const vector<TYPE>& in) {
    auto avg = average (in);
    float s = 0;
    for (auto const& x : in) {
      auto v = x - avg;
      s += (v * v);
    }
    return sqrt(s / (in.size()-1));
  }

  template <class TYPE>
  bool mannWhitney (vector<TYPE>& a,
		    vector<TYPE>& b,
		    float significanceLevel = 0.05)
  {
    assert (a.size() == b.size());

    sort (a.begin(), a.end());
    sort (b.begin(), b.end());

    vector<pair<TYPE,int>> combined;

    for (auto x : a) { combined.push_back (pair<TYPE,int>(x+drand48(),0)); }
    for (auto x : b) { combined.push_back (pair<TYPE,int>(x+drand48(),1)); }

    sort (combined.begin(), combined.end());

    // Compute ranks. For now, ignore ties.
    auto index = 1;
    auto aRanks = 0;
    for (auto x : combined) {
      if (x.second == 0) {
	aRanks += index;
      }
      index++;
    }
    
    cout << "RANKS = " << aRanks << endl;

    auto n1 = a.size();
    auto n2 = b.size();
    auto N  = n1 + n2;

    auto U = aRanks - (n1 * (n1+1))/2.0;
    cout << "aRanks = " << aRanks << endl;
    cout << "U = " << U << endl;
    auto s = sqrt ((n1*n2)*(n1+n2+1.0)/12.0);
    auto Z = fabs((U - (n1*n2)/2.0) / s);
    cout << "Z = " << Z << endl;
    return false;
  }

  void testMannWhitney() {
    vector<int> a = {0, 6, 7, 8, 9, 10};
    vector<int> b = {1, 2, 3, 4, 5, 11};
    cout << mannWhitney (a, b) << endl;
  }

  template <class TYPE>
  bool meanDistance (vector<TYPE>& a,
		     vector<TYPE>& b,
		     float significanceLevel = 0.05)
  {
    assert (a.size() == b.size());

    sort (a.begin(), a.end());
    sort (b.begin(), b.end());

    //    auto aAverage = a[a.size()/2]; // average (a);
    //    auto bAverage = b[b.size()/2]; // average (b);
    auto aAverage = average (a);
    auto bAverage = average (b);

    auto aLeftInterval  = floor(significanceLevel / 2.0 * a.size());
    auto aRightInterval = ceil((1.0 - significanceLevel / 2.0) * a.size());

    auto bLeftInterval  = floor(significanceLevel / 2.0 * b.size());
    auto bRightInterval = ceil((1.0 - significanceLevel / 2.0) * b.size());

    bool result;
    if ((aAverage < b[bLeftInterval]) ||
	(aAverage > b[bRightInterval]) ||
	(bAverage < a[aLeftInterval]) ||
	(bAverage > a[aRightInterval])) {
      result = true;
    } else {
      result = false;
    }
    return result;
  }

  template <class TYPE>
  float confidencePermutationTest (const vector<TYPE>& a,
				   const vector<TYPE>& b,
				   const int iterations = 1000)
  {
    auto originalMeanDiff = fabs((float) average (a) - (float) average (b));

    cout << "original mean diff = " << originalMeanDiff << endl;

    // Combine a and b into a vector called mix.
    vector<TYPE> mix;
    mix.resize (a.size() + b.size());

    {
      auto index = 0;
      for (auto const& x : a) {
	mix[index++] = x;
      }
      for (auto const& x : b) {
	mix[index++] = x;
      }
    }
    
    // Now repeatedly construct two different permutations of this mix,
    // and compute their averages. We count the number of times the original average
    // is smaller than the average of the permuted samples.
    auto count = 0;
    float minDiff = 1e99;
    float maxDiff = -1e99;
    for (auto i = 0; i < iterations; i++) {
      fyshuffle::inplace (mix);
      float s1 = 0.0, s2 = 0.0;
      for (auto j = 0; j < a.size(); j++) {
	s1 += mix[j];
      }
      for (auto j = a.size(); j < a.size() + b.size(); j++) {
	s2 += mix[j];
      }
      float currDiff = fabs(s1/a.size() - s2/b.size());
      if (minDiff > currDiff) { minDiff = currDiff; }
      if (maxDiff < currDiff) { maxDiff = currDiff; }
      if (originalMeanDiff <= currDiff) {
	count++;
      }
    }
    cout << "count = " << count << endl;
    cout << "minDiff = " << minDiff << endl;
    cout << "maxDiff = " << maxDiff << endl;
    return (float) count / (float) iterations;
  }

  template <class TYPE>
  float overlapFraction (vector<TYPE>& a,
			 vector<TYPE>& b)
  {
    sort (a.begin(), a.end());
    sort (b.begin(), b.end());

    auto counter = 0;

    vector<TYPE> vecs[2];
    vecs[0] = a;
    vecs[1] = b;
    float range[2][2] = {{ a[0], a[a.size()-1] },
			 { b[0], b[b.size()-1] }};

    for (int i = 0; i < 2; i++) {
      for (int index = 0; index < vecs[i].size(); index++) {
	if ((vecs[i][index] >= range[1-i][0]) &&
	    (vecs[i][index] <= range[1-i][1])) {
	  counter++;
	}
      }
    }

    return (float) counter / (float) (a.size() + b.size());
  }

  /// @brief returns true iff a and b are significantly different.
  /// i.e., it's safe to reject the null hypothesis that they are from
  /// the same distribution.
  template <class TYPE>
  bool kolmogorovSmirnoff (vector<TYPE>& a,
			   vector<TYPE>& b,
			   float significanceLevel = 0.001)
  {
    sort (a.begin(), a.end());
    sort (b.begin(), b.end());
    assert (a.size() == b.size());
    auto max = -1.0;
    for (auto i = 0; i < a.size(); i++) {
      auto val = fabs(a[i]- b[i]);
      if (val > max) {
	max = val;
      }
    }
    // c(0.001) = 1.95
    // Reject the null hypothesis if KS > c(alpha) * critical value.
    // NB: right now we just use a significance level of 0.001!
    auto criticalValue = 2.0 * sqrt(((a.size()*a.size())/(2.0 * a.size())));
    auto KS = sqrt(((a.size()*a.size())/(2.0 * a.size())) * max);
    return (KS > criticalValue);
  }


}

#endif
